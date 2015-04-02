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
    public class SocialWorkAttendanceController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: SocialWorkAttendance
        public async Task<ActionResult> Index()
        {
            return View(await db.SocialWorkAttendanceModels.ToListAsync());
        }

        // GET: SocialWorkAttendance/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialWorkAttendanceModel socialWorkAttendanceModel = await db.SocialWorkAttendanceModels.FindAsync(id);
            if (socialWorkAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(socialWorkAttendanceModel);
        }

        // GET: SocialWorkAttendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialWorkAttendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SocialWorkAttendanceId,SocialWorkAttendance")] SocialWorkAttendanceModel socialWorkAttendanceModel)
        {
            if (ModelState.IsValid)
            {
                db.SocialWorkAttendanceModels.Add(socialWorkAttendanceModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(socialWorkAttendanceModel);
        }

        // GET: SocialWorkAttendance/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialWorkAttendanceModel socialWorkAttendanceModel = await db.SocialWorkAttendanceModels.FindAsync(id);
            if (socialWorkAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(socialWorkAttendanceModel);
        }

        // POST: SocialWorkAttendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SocialWorkAttendanceId,SocialWorkAttendance")] SocialWorkAttendanceModel socialWorkAttendanceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialWorkAttendanceModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(socialWorkAttendanceModel);
        }

        // GET: SocialWorkAttendance/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialWorkAttendanceModel socialWorkAttendanceModel = await db.SocialWorkAttendanceModels.FindAsync(id);
            if (socialWorkAttendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(socialWorkAttendanceModel);
        }

        // POST: SocialWorkAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SocialWorkAttendanceModel socialWorkAttendanceModel = await db.SocialWorkAttendanceModels.FindAsync(id);
            db.SocialWorkAttendanceModels.Remove(socialWorkAttendanceModel);
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
