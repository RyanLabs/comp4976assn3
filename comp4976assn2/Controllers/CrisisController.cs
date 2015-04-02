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
    public class CrisisController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Crisis
        public async Task<ActionResult> Index()
        {
            return View(await db.CrisisModels.ToListAsync());
        }

        // GET: Crisis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrisisModel crisisModel = await db.CrisisModels.FindAsync(id);
            if (crisisModel == null)
            {
                return HttpNotFound();
            }
            return View(crisisModel);
        }

        // GET: Crisis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crisis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CrisisId,Crisis")] CrisisModel crisisModel)
        {
            if (ModelState.IsValid)
            {
                db.CrisisModels.Add(crisisModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(crisisModel);
        }

        // GET: Crisis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrisisModel crisisModel = await db.CrisisModels.FindAsync(id);
            if (crisisModel == null)
            {
                return HttpNotFound();
            }
            return View(crisisModel);
        }

        // POST: Crisis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CrisisId,Crisis")] CrisisModel crisisModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crisisModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(crisisModel);
        }

        // GET: Crisis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrisisModel crisisModel = await db.CrisisModels.FindAsync(id);
            if (crisisModel == null)
            {
                return HttpNotFound();
            }
            return View(crisisModel);
        }

        // POST: Crisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CrisisModel crisisModel = await db.CrisisModels.FindAsync(id);
            db.CrisisModels.Remove(crisisModel);
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
