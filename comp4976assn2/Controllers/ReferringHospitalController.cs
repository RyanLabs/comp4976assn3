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
    public class ReferringHospitalController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ReferringHospital
        public async Task<ActionResult> Index()
        {
            return View(await db.ReferringHospitalModels.ToListAsync());
        }

        // GET: ReferringHospital/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferringHospitalModel referringHospitalModel = await db.ReferringHospitalModels.FindAsync(id);
            if (referringHospitalModel == null)
            {
                return HttpNotFound();
            }
            return View(referringHospitalModel);
        }

        // GET: ReferringHospital/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferringHospital/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReferringHospitalId,ReferringHospital")] ReferringHospitalModel referringHospitalModel)
        {
            if (ModelState.IsValid)
            {
                db.ReferringHospitalModels.Add(referringHospitalModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(referringHospitalModel);
        }

        // GET: ReferringHospital/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferringHospitalModel referringHospitalModel = await db.ReferringHospitalModels.FindAsync(id);
            if (referringHospitalModel == null)
            {
                return HttpNotFound();
            }
            return View(referringHospitalModel);
        }

        // POST: ReferringHospital/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReferringHospitalId,ReferringHospital")] ReferringHospitalModel referringHospitalModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referringHospitalModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(referringHospitalModel);
        }

        // GET: ReferringHospital/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferringHospitalModel referringHospitalModel = await db.ReferringHospitalModels.FindAsync(id);
            if (referringHospitalModel == null)
            {
                return HttpNotFound();
            }
            return View(referringHospitalModel);
        }

        // POST: ReferringHospital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReferringHospitalModel referringHospitalModel = await db.ReferringHospitalModels.FindAsync(id);
            db.ReferringHospitalModels.Remove(referringHospitalModel);
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
