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
    public class FiscalYearController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: FiscalYear
        public async Task<ActionResult> Index()
        {
            return View(await db.FiscalYearModels.ToListAsync());
        }

        // GET: FiscalYear/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYearModel fiscalYearModel = await db.FiscalYearModels.FindAsync(id);
            if (fiscalYearModel == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYearModel);
        }

        // GET: FiscalYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FiscalYear/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FiscalId,FiscalYear")] FiscalYearModel fiscalYearModel)
        {
            if (ModelState.IsValid)
            {
                db.FiscalYearModels.Add(fiscalYearModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fiscalYearModel);
        }

        // GET: FiscalYear/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYearModel fiscalYearModel = await db.FiscalYearModels.FindAsync(id);
            if (fiscalYearModel == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYearModel);
        }

        // POST: FiscalYear/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FiscalId,FiscalYear")] FiscalYearModel fiscalYearModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiscalYearModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fiscalYearModel);
        }

        // GET: FiscalYear/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYearModel fiscalYearModel = await db.FiscalYearModels.FindAsync(id);
            if (fiscalYearModel == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYearModel);
        }

        // POST: FiscalYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FiscalYearModel fiscalYearModel = await db.FiscalYearModels.FindAsync(id);
            db.FiscalYearModels.Remove(fiscalYearModel);
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
