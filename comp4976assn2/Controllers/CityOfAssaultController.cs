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
    public class CityOfAssaultController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: CityOfAssault
        public async Task<ActionResult> Index()
        {
            return View(await db.CityOfAssaultModels.ToListAsync());
        }

        // GET: CityOfAssault/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityOfAssaultModel cityOfAssaultModel = await db.CityOfAssaultModels.FindAsync(id);
            if (cityOfAssaultModel == null)
            {
                return HttpNotFound();
            }
            return View(cityOfAssaultModel);
        }

        // GET: CityOfAssault/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityOfAssault/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CityOfAssaultId,CityOfAssault")] CityOfAssaultModel cityOfAssaultModel)
        {
            if (ModelState.IsValid)
            {
                db.CityOfAssaultModels.Add(cityOfAssaultModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cityOfAssaultModel);
        }

        // GET: CityOfAssault/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityOfAssaultModel cityOfAssaultModel = await db.CityOfAssaultModels.FindAsync(id);
            if (cityOfAssaultModel == null)
            {
                return HttpNotFound();
            }
            return View(cityOfAssaultModel);
        }

        // POST: CityOfAssault/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CityOfAssaultId,CityOfAssault")] CityOfAssaultModel cityOfAssaultModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityOfAssaultModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cityOfAssaultModel);
        }

        // GET: CityOfAssault/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityOfAssaultModel cityOfAssaultModel = await db.CityOfAssaultModels.FindAsync(id);
            if (cityOfAssaultModel == null)
            {
                return HttpNotFound();
            }
            return View(cityOfAssaultModel);
        }

        // POST: CityOfAssault/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CityOfAssaultModel cityOfAssaultModel = await db.CityOfAssaultModels.FindAsync(id);
            db.CityOfAssaultModels.Remove(cityOfAssaultModel);
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
