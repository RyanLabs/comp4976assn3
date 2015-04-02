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
    public class PoliceAttendanceController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: PoliceAttendance
        public async Task<ActionResult> Index()
        {
            return View(await db.PoliceAttendanceModels.ToListAsync());
        }

        // GET: PoliceAttendance/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendanceModel policeAttendanceModel = await db.PoliceAttendanceModels.FindAsync(id);
            if (policeAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendanceModel);
        }

        // GET: PoliceAttendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliceAttendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PoliceAttendanceId,PoliceAttendance")] PoliceAttendanceModel policeAttendanceModel)
        {
            if (ModelState.IsValid)
            {
                db.PoliceAttendanceModels.Add(policeAttendanceModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(policeAttendanceModel);
        }

        // GET: PoliceAttendance/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendanceModel policeAttendanceModel = await db.PoliceAttendanceModels.FindAsync(id);
            if (policeAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendanceModel);
        }

        // POST: PoliceAttendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PoliceAttendanceId,PoliceAttendance")] PoliceAttendanceModel policeAttendanceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policeAttendanceModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(policeAttendanceModel);
        }

        // GET: PoliceAttendance/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendanceModel policeAttendanceModel = await db.PoliceAttendanceModels.FindAsync(id);
            if (policeAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendanceModel);
        }

        // POST: PoliceAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PoliceAttendanceModel policeAttendanceModel = await db.PoliceAttendanceModels.FindAsync(id);
            db.PoliceAttendanceModels.Remove(policeAttendanceModel);
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
