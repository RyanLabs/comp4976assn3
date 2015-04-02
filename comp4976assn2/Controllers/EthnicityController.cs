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
using comp4976assn2.Models.ClientEntity;

namespace comp4976assn2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EthnicityController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Ethnicity
        public async Task<ActionResult> Index()
        {
            return View(await db.EthnicityModels.ToListAsync());
        }

        // GET: Ethnicity/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EthnicityModel ethnicityModel = await db.EthnicityModels.FindAsync(id);
            if (ethnicityModel == null)
            {
                return HttpNotFound();
            }
            return View(ethnicityModel);
        }

        // GET: Ethnicity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ethnicity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EthnicityId,Ethnicity")] EthnicityModel ethnicityModel)
        {
            if (ModelState.IsValid)
            {
                db.EthnicityModels.Add(ethnicityModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ethnicityModel);
        }

        // GET: Ethnicity/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EthnicityModel ethnicityModel = await db.EthnicityModels.FindAsync(id);
            if (ethnicityModel == null)
            {
                return HttpNotFound();
            }
            return View(ethnicityModel);
        }

        // POST: Ethnicity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EthnicityId,Ethnicity")] EthnicityModel ethnicityModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ethnicityModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ethnicityModel);
        }

        // GET: Ethnicity/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EthnicityModel ethnicityModel = await db.EthnicityModels.FindAsync(id);
            if (ethnicityModel == null)
            {
                return HttpNotFound();
            }
            return View(ethnicityModel);
        }

        // POST: Ethnicity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EthnicityModel ethnicityModel = await db.EthnicityModels.FindAsync(id);
            db.EthnicityModels.Remove(ethnicityModel);
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
