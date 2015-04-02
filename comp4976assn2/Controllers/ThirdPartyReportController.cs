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
    public class ThirdPartyReportController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ThirdPartyReport
        public async Task<ActionResult> Index()
        {
            return View(await db.ThirdPartyReportModels.ToListAsync());
        }

        // GET: ThirdPartyReport/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThirdPartyReportModel thirdPartyReportModel = await db.ThirdPartyReportModels.FindAsync(id);
            if (thirdPartyReportModel == null)
            {
                return HttpNotFound();
            }
            return View(thirdPartyReportModel);
        }

        // GET: ThirdPartyReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThirdPartyReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ThirdPartyReportId,ThirdPartyReport")] ThirdPartyReportModel thirdPartyReportModel)
        {
            if (ModelState.IsValid)
            {
                db.ThirdPartyReportModels.Add(thirdPartyReportModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(thirdPartyReportModel);
        }

        // GET: ThirdPartyReport/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThirdPartyReportModel thirdPartyReportModel = await db.ThirdPartyReportModels.FindAsync(id);
            if (thirdPartyReportModel == null)
            {
                return HttpNotFound();
            }
            return View(thirdPartyReportModel);
        }

        // POST: ThirdPartyReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ThirdPartyReportId,ThirdPartyReport")] ThirdPartyReportModel thirdPartyReportModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thirdPartyReportModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(thirdPartyReportModel);
        }

        // GET: ThirdPartyReport/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThirdPartyReportModel thirdPartyReportModel = await db.ThirdPartyReportModels.FindAsync(id);
            if (thirdPartyReportModel == null)
            {
                return HttpNotFound();
            }
            return View(thirdPartyReportModel);
        }

        // POST: ThirdPartyReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ThirdPartyReportModel thirdPartyReportModel = await db.ThirdPartyReportModels.FindAsync(id);
            db.ThirdPartyReportModels.Remove(thirdPartyReportModel);
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
