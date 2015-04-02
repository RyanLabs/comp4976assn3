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
    public class DuplicateFileController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: DuplicateFile
        public async Task<ActionResult> Index()
        {
            return View(await db.DuplicateFileModels.ToListAsync());
        }

        // GET: DuplicateFile/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuplicateFileModel duplicateFileModel = await db.DuplicateFileModels.FindAsync(id);
            if (duplicateFileModel == null)
            {
                return HttpNotFound();
            }
            return View(duplicateFileModel);
        }

        // GET: DuplicateFile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DuplicateFile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DuplicateFileId,DuplicateFile")] DuplicateFileModel duplicateFileModel)
        {
            if (ModelState.IsValid)
            {
                db.DuplicateFileModels.Add(duplicateFileModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(duplicateFileModel);
        }

        // GET: DuplicateFile/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuplicateFileModel duplicateFileModel = await db.DuplicateFileModels.FindAsync(id);
            if (duplicateFileModel == null)
            {
                return HttpNotFound();
            }
            return View(duplicateFileModel);
        }

        // POST: DuplicateFile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DuplicateFileId,DuplicateFile")] DuplicateFileModel duplicateFileModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duplicateFileModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(duplicateFileModel);
        }

        // GET: DuplicateFile/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuplicateFileModel duplicateFileModel = await db.DuplicateFileModels.FindAsync(id);
            if (duplicateFileModel == null)
            {
                return HttpNotFound();
            }
            return View(duplicateFileModel);
        }

        // POST: DuplicateFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DuplicateFileModel duplicateFileModel = await db.DuplicateFileModels.FindAsync(id);
            db.DuplicateFileModels.Remove(duplicateFileModel);
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
