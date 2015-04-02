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
    public class HospitalAttendedController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: HospitalAttended
        public async Task<ActionResult> Index()
        {
            return View(await db.HospitalAttendedModels.ToListAsync());
        }

        // GET: HospitalAttended/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalAttendedModel hospitalAttendedModel = await db.HospitalAttendedModels.FindAsync(id);
            if (hospitalAttendedModel == null)
            {
                return HttpNotFound();
            }
            return View(hospitalAttendedModel);
        }

        // GET: HospitalAttended/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HospitalAttended/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HospitalAttendedId,HospitalAttended")] HospitalAttendedModel hospitalAttendedModel)
        {
            if (ModelState.IsValid)
            {
                db.HospitalAttendedModels.Add(hospitalAttendedModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hospitalAttendedModel);
        }

        // GET: HospitalAttended/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalAttendedModel hospitalAttendedModel = await db.HospitalAttendedModels.FindAsync(id);
            if (hospitalAttendedModel == null)
            {
                return HttpNotFound();
            }
            return View(hospitalAttendedModel);
        }

        // POST: HospitalAttended/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HospitalAttendedId,HospitalAttended")] HospitalAttendedModel hospitalAttendedModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitalAttendedModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hospitalAttendedModel);
        }

        // GET: HospitalAttended/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalAttendedModel hospitalAttendedModel = await db.HospitalAttendedModels.FindAsync(id);
            if (hospitalAttendedModel == null)
            {
                return HttpNotFound();
            }
            return View(hospitalAttendedModel);
        }

        // POST: HospitalAttended/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HospitalAttendedModel hospitalAttendedModel = await db.HospitalAttendedModels.FindAsync(id);
            db.HospitalAttendedModels.Remove(hospitalAttendedModel);
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
