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
    public class FamilyViolenceFileController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: FamilyViolenceFile
        public async Task<ActionResult> Index()
        {
            return View(await db.FamilyViolenceFileModels.ToListAsync());
        }

        // GET: FamilyViolenceFile/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyViolenceFileModel familyViolenceFileModel = await db.FamilyViolenceFileModels.FindAsync(id);
            if (familyViolenceFileModel == null)
            {
                return HttpNotFound();
            }
            return View(familyViolenceFileModel);
        }

        // GET: FamilyViolenceFile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamilyViolenceFile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FamilyViolenceId,FamilyViolenceFile")] FamilyViolenceFileModel familyViolenceFileModel)
        {
            if (ModelState.IsValid)
            {
                db.FamilyViolenceFileModels.Add(familyViolenceFileModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(familyViolenceFileModel);
        }

        // GET: FamilyViolenceFile/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyViolenceFileModel familyViolenceFileModel = await db.FamilyViolenceFileModels.FindAsync(id);
            if (familyViolenceFileModel == null)
            {
                return HttpNotFound();
            }
            return View(familyViolenceFileModel);
        }

        // POST: FamilyViolenceFile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FamilyViolenceId,FamilyViolenceFile")] FamilyViolenceFileModel familyViolenceFileModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyViolenceFileModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(familyViolenceFileModel);
        }

        // GET: FamilyViolenceFile/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyViolenceFileModel familyViolenceFileModel = await db.FamilyViolenceFileModels.FindAsync(id);
            if (familyViolenceFileModel == null)
            {
                return HttpNotFound();
            }
            return View(familyViolenceFileModel);
        }

        // POST: FamilyViolenceFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FamilyViolenceFileModel familyViolenceFileModel = await db.FamilyViolenceFileModels.FindAsync(id);
            db.FamilyViolenceFileModels.Remove(familyViolenceFileModel);
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
