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
    public class RiskLevelController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: RiskLevel
        public async Task<ActionResult> Index()
        {
            return View(await db.RiskLevelModels.ToListAsync());
        }

        // GET: RiskLevel/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevelModel riskLevelModel = await db.RiskLevelModels.FindAsync(id);
            if (riskLevelModel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevelModel);
        }

        // GET: RiskLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RiskLevelId,RiskLevel")] RiskLevelModel riskLevelModel)
        {
            if (ModelState.IsValid)
            {
                db.RiskLevelModels.Add(riskLevelModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(riskLevelModel);
        }

        // GET: RiskLevel/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevelModel riskLevelModel = await db.RiskLevelModels.FindAsync(id);
            if (riskLevelModel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevelModel);
        }

        // POST: RiskLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RiskLevelId,RiskLevel")] RiskLevelModel riskLevelModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskLevelModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(riskLevelModel);
        }

        // GET: RiskLevel/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevelModel riskLevelModel = await db.RiskLevelModels.FindAsync(id);
            if (riskLevelModel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevelModel);
        }

        // POST: RiskLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RiskLevelModel riskLevelModel = await db.RiskLevelModels.FindAsync(id);
            db.RiskLevelModels.Remove(riskLevelModel);
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
