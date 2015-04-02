using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comp4976assn2.Models;
using comp4976assn2.Models.SmartEntity;

namespace comp4976assn2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CityOfResidenceController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: CityOfResidence
        public async Task<ActionResult> Index()
        {
            return View(await db.CityOfResidenceModels.ToListAsync());
        }

        // GET: CityOfResidence/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityOfResidenceModel cityOfResidenceModel = await db.CityOfResidenceModels.FindAsync(id);
            if (cityOfResidenceModel == null)
            {
                return HttpNotFound();
            }
            return View(cityOfResidenceModel);
        }

        // GET: CityOfResidence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityOfResidence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CityOfResidenceId,CityOfResidence")] CityOfResidenceModel cityOfResidenceModel)
        {
            if (ModelState.IsValid)
            {
                db.CityOfResidenceModels.Add(cityOfResidenceModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cityOfResidenceModel);
        }

        // GET: CityOfResidence/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityOfResidenceModel cityOfResidenceModel = await db.CityOfResidenceModels.FindAsync(id);
            if (cityOfResidenceModel == null)
            {
                return HttpNotFound();
            }
            return View(cityOfResidenceModel);
        }

        // POST: CityOfResidence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CityOfResidenceId,CityOfResidence")] CityOfResidenceModel cityOfResidenceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityOfResidenceModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cityOfResidenceModel);
        }

        // GET: CityOfResidence/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityOfResidenceModel cityOfResidenceModel = await db.CityOfResidenceModels.FindAsync(id);
            if (cityOfResidenceModel == null)
            {
                return HttpNotFound();
            }
            return View(cityOfResidenceModel);
        }

        // POST: CityOfResidence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CityOfResidenceModel cityOfResidenceModel = await db.CityOfResidenceModels.FindAsync(id);
            db.CityOfResidenceModels.Remove(cityOfResidenceModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
