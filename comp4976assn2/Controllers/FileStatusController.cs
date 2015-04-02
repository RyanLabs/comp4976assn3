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
    public class FileStatusController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: FileStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.FileStatusModels.ToListAsync());
        }

        // GET: FileStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileStatusModel fileStatusModel = await db.FileStatusModels.FindAsync(id);
            if (fileStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(fileStatusModel);
        }

        // GET: FileStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FileStatusId,FileStatus")] FileStatusModel fileStatusModel)
        {
            if (ModelState.IsValid)
            {
                db.FileStatusModels.Add(fileStatusModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fileStatusModel);
        }

        // GET: FileStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileStatusModel fileStatusModel = await db.FileStatusModels.FindAsync(id);
            if (fileStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(fileStatusModel);
        }

        // POST: FileStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FileStatusId,FileStatus")] FileStatusModel fileStatusModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileStatusModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fileStatusModel);
        }

        // GET: FileStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileStatusModel fileStatusModel = await db.FileStatusModels.FindAsync(id);
            if (fileStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(fileStatusModel);
        }

        // POST: FileStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FileStatusModel fileStatusModel = await db.FileStatusModels.FindAsync(id);
            db.FileStatusModels.Remove(fileStatusModel);
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
