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
    public class VictimServicesAttendanceController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: VictimServicesAttendance
        public async Task<ActionResult> Index()
        {
            return View(await db.VictimServicesAttendanceModels.ToListAsync());
        }

        // GET: VictimServicesAttendance/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendanceModel victimServicesAttendanceModel = await db.VictimServicesAttendanceModels.FindAsync(id);
            if (victimServicesAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendanceModel);
        }

        // GET: VictimServicesAttendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VictimServicesAttendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VictimServicesAttendanceId,VictimServicesAttendance")] VictimServicesAttendanceModel victimServicesAttendanceModel)
        {
            if (ModelState.IsValid)
            {
                db.VictimServicesAttendanceModels.Add(victimServicesAttendanceModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(victimServicesAttendanceModel);
        }

        // GET: VictimServicesAttendance/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendanceModel victimServicesAttendanceModel = await db.VictimServicesAttendanceModels.FindAsync(id);
            if (victimServicesAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendanceModel);
        }

        // POST: VictimServicesAttendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VictimServicesAttendanceId,VictimServicesAttendance")] VictimServicesAttendanceModel victimServicesAttendanceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victimServicesAttendanceModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(victimServicesAttendanceModel);
        }

        // GET: VictimServicesAttendance/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendanceModel victimServicesAttendanceModel = await db.VictimServicesAttendanceModels.FindAsync(id);
            if (victimServicesAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendanceModel);
        }

        // POST: VictimServicesAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VictimServicesAttendanceModel victimServicesAttendanceModel = await db.VictimServicesAttendanceModels.FindAsync(id);
            db.VictimServicesAttendanceModels.Remove(victimServicesAttendanceModel);
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
