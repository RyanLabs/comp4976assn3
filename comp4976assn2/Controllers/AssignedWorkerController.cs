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
    public class AssignedWorkerController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: AssignedWorker
        public async Task<ActionResult> Index()
        {
            return View(await db.AssignedWorkerModels.ToListAsync());
        }

        // GET: AssignedWorker/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorkerModel assignedWorkerModel = await db.AssignedWorkerModels.FindAsync(id);
            if (assignedWorkerModel == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorkerModel);
        }

        // GET: AssignedWorker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssignedWorker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AssignedWorkerId,AssignedWorker")] AssignedWorkerModel assignedWorkerModel)
        {
            if (ModelState.IsValid)
            {
                db.AssignedWorkerModels.Add(assignedWorkerModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(assignedWorkerModel);
        }

        // GET: AssignedWorker/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorkerModel assignedWorkerModel = await db.AssignedWorkerModels.FindAsync(id);
            if (assignedWorkerModel == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorkerModel);
        }

        // POST: AssignedWorker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AssignedWorkerId,AssignedWorker")] AssignedWorkerModel assignedWorkerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedWorkerModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(assignedWorkerModel);
        }

        // GET: AssignedWorker/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorkerModel assignedWorkerModel = await db.AssignedWorkerModels.FindAsync(id);
            if (assignedWorkerModel == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorkerModel);
        }

        // POST: AssignedWorker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AssignedWorkerModel assignedWorkerModel = await db.AssignedWorkerModels.FindAsync(id);
            db.AssignedWorkerModels.Remove(assignedWorkerModel);
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
