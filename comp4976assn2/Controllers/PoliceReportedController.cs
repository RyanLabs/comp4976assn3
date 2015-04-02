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
    public class PoliceReportedController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: PoliceReported
        public async Task<ActionResult> Index()
        {
            return View(await db.PoliceReportedModels.ToListAsync());
        }

        // GET: PoliceReported/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceReportedModel policeReportedModel = await db.PoliceReportedModels.FindAsync(id);
            if (policeReportedModel == null)
            {
                return HttpNotFound();
            }
            return View(policeReportedModel);
        }

        // GET: PoliceReported/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliceReported/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PoliceReportedId,PoliceReported")] PoliceReportedModel policeReportedModel)
        {
            if (ModelState.IsValid)
            {
                db.PoliceReportedModels.Add(policeReportedModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(policeReportedModel);
        }

        // GET: PoliceReported/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceReportedModel policeReportedModel = await db.PoliceReportedModels.FindAsync(id);
            if (policeReportedModel == null)
            {
                return HttpNotFound();
            }
            return View(policeReportedModel);
        }

        // POST: PoliceReported/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PoliceReportedId,PoliceReported")] PoliceReportedModel policeReportedModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policeReportedModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(policeReportedModel);
        }

        // GET: PoliceReported/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceReportedModel policeReportedModel = await db.PoliceReportedModels.FindAsync(id);
            if (policeReportedModel == null)
            {
                return HttpNotFound();
            }
            return View(policeReportedModel);
        }

        // POST: PoliceReported/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PoliceReportedModel policeReportedModel = await db.PoliceReportedModels.FindAsync(id);
            db.PoliceReportedModels.Remove(policeReportedModel);
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
