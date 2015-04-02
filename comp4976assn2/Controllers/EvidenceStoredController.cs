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
    public class EvidenceStoredController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: EvidenceStored
        public async Task<ActionResult> Index()
        {
            return View(await db.EvidenceStoredModels.ToListAsync());
        }

        // GET: EvidenceStored/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceStoredModel evidenceStoredModel = await db.EvidenceStoredModels.FindAsync(id);
            if (evidenceStoredModel == null)
            {
                return HttpNotFound();
            }
            return View(evidenceStoredModel);
        }

        // GET: EvidenceStored/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EvidenceStored/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EvidenceStoredId,EvidenceStored")] EvidenceStoredModel evidenceStoredModel)
        {
            if (ModelState.IsValid)
            {
                db.EvidenceStoredModels.Add(evidenceStoredModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(evidenceStoredModel);
        }

        // GET: EvidenceStored/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceStoredModel evidenceStoredModel = await db.EvidenceStoredModels.FindAsync(id);
            if (evidenceStoredModel == null)
            {
                return HttpNotFound();
            }
            return View(evidenceStoredModel);
        }

        // POST: EvidenceStored/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EvidenceStoredId,EvidenceStored")] EvidenceStoredModel evidenceStoredModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evidenceStoredModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(evidenceStoredModel);
        }

        // GET: EvidenceStored/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceStoredModel evidenceStoredModel = await db.EvidenceStoredModels.FindAsync(id);
            if (evidenceStoredModel == null)
            {
                return HttpNotFound();
            }
            return View(evidenceStoredModel);
        }

        // POST: EvidenceStored/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EvidenceStoredModel evidenceStoredModel = await db.EvidenceStoredModels.FindAsync(id);
            db.EvidenceStoredModels.Remove(evidenceStoredModel);
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
