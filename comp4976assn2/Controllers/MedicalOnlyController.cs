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
    public class MedicalOnlyController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: MedicalOnly
        public async Task<ActionResult> Index()
        {
            return View(await db.MedicalOnlyModels.ToListAsync());
        }

        // GET: MedicalOnly/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalOnlyModel medicalOnlyModel = await db.MedicalOnlyModels.FindAsync(id);
            if (medicalOnlyModel == null)
            {
                return HttpNotFound();
            }
            return View(medicalOnlyModel);
        }

        // GET: MedicalOnly/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalOnly/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MedicalOnlyId,MedicalOnly")] MedicalOnlyModel medicalOnlyModel)
        {
            if (ModelState.IsValid)
            {
                db.MedicalOnlyModels.Add(medicalOnlyModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(medicalOnlyModel);
        }

        // GET: MedicalOnly/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalOnlyModel medicalOnlyModel = await db.MedicalOnlyModels.FindAsync(id);
            if (medicalOnlyModel == null)
            {
                return HttpNotFound();
            }
            return View(medicalOnlyModel);
        }

        // POST: MedicalOnly/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MedicalOnlyId,MedicalOnly")] MedicalOnlyModel medicalOnlyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalOnlyModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(medicalOnlyModel);
        }

        // GET: MedicalOnly/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalOnlyModel medicalOnlyModel = await db.MedicalOnlyModels.FindAsync(id);
            if (medicalOnlyModel == null)
            {
                return HttpNotFound();
            }
            return View(medicalOnlyModel);
        }

        // POST: MedicalOnly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MedicalOnlyModel medicalOnlyModel = await db.MedicalOnlyModels.FindAsync(id);
            db.MedicalOnlyModels.Remove(medicalOnlyModel);
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
