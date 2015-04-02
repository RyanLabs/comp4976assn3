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
    public class RiskStatusController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: RiskStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.RiskStatusModels.ToListAsync());
        }

        // GET: RiskStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskStatusModel riskStatusModel = await db.RiskStatusModels.FindAsync(id);
            if (riskStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(riskStatusModel);
        }

        // GET: RiskStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RiskStatusId,RiskStatus")] RiskStatusModel riskStatusModel)
        {
            if (ModelState.IsValid)
            {
                db.RiskStatusModels.Add(riskStatusModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(riskStatusModel);
        }

        // GET: RiskStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskStatusModel riskStatusModel = await db.RiskStatusModels.FindAsync(id);
            if (riskStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(riskStatusModel);
        }

        // POST: RiskStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RiskStatusId,RiskStatus")] RiskStatusModel riskStatusModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskStatusModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(riskStatusModel);
        }

        // GET: RiskStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskStatusModel riskStatusModel = await db.RiskStatusModels.FindAsync(id);
            if (riskStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(riskStatusModel);
        }

        // POST: RiskStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RiskStatusModel riskStatusModel = await db.RiskStatusModels.FindAsync(id);
            db.RiskStatusModels.Remove(riskStatusModel);
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
