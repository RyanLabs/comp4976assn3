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
    public class ReferredToCBVSController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ReferredToCBVS
        public async Task<ActionResult> Index()
        {
            return View(await db.ReferredToCbvsModels.ToListAsync());
        }

        // GET: ReferredToCBVS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferredToCBVSModel referredToCBVSModel = await db.ReferredToCbvsModels.FindAsync(id);
            if (referredToCBVSModel == null)
            {
                return HttpNotFound();
            }
            return View(referredToCBVSModel);
        }

        // GET: ReferredToCBVS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferredToCBVS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReferredToCBVSId,ReferredToCBVS")] ReferredToCBVSModel referredToCBVSModel)
        {
            if (ModelState.IsValid)
            {
                db.ReferredToCbvsModels.Add(referredToCBVSModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(referredToCBVSModel);
        }

        // GET: ReferredToCBVS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferredToCBVSModel referredToCBVSModel = await db.ReferredToCbvsModels.FindAsync(id);
            if (referredToCBVSModel == null)
            {
                return HttpNotFound();
            }
            return View(referredToCBVSModel);
        }

        // POST: ReferredToCBVS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReferredToCBVSId,ReferredToCBVS")] ReferredToCBVSModel referredToCBVSModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referredToCBVSModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(referredToCBVSModel);
        }

        // GET: ReferredToCBVS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferredToCBVSModel referredToCBVSModel = await db.ReferredToCbvsModels.FindAsync(id);
            if (referredToCBVSModel == null)
            {
                return HttpNotFound();
            }
            return View(referredToCBVSModel);
        }

        // POST: ReferredToCBVS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReferredToCBVSModel referredToCBVSModel = await db.ReferredToCbvsModels.FindAsync(id);
            db.ReferredToCbvsModels.Remove(referredToCBVSModel);
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
