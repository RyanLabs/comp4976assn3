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
    public class ReferralSourceController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ReferralSource
        public async Task<ActionResult> Index()
        {
            return View(await db.ReferralSourceModels.ToListAsync());
        }

        // GET: ReferralSource/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralSourceModel referralSourceModel = await db.ReferralSourceModels.FindAsync(id);
            if (referralSourceModel == null)
            {
                return HttpNotFound();
            }
            return View(referralSourceModel);
        }

        // GET: ReferralSource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferralSource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReferralSourceId,ReferralSource")] ReferralSourceModel referralSourceModel)
        {
            if (ModelState.IsValid)
            {
                db.ReferralSourceModels.Add(referralSourceModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(referralSourceModel);
        }

        // GET: ReferralSource/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralSourceModel referralSourceModel = await db.ReferralSourceModels.FindAsync(id);
            if (referralSourceModel == null)
            {
                return HttpNotFound();
            }
            return View(referralSourceModel);
        }

        // POST: ReferralSource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReferralSourceId,ReferralSource")] ReferralSourceModel referralSourceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referralSourceModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(referralSourceModel);
        }

        // GET: ReferralSource/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralSourceModel referralSourceModel = await db.ReferralSourceModels.FindAsync(id);
            if (referralSourceModel == null)
            {
                return HttpNotFound();
            }
            return View(referralSourceModel);
        }

        // POST: ReferralSource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReferralSourceModel referralSourceModel = await db.ReferralSourceModels.FindAsync(id);
            db.ReferralSourceModels.Remove(referralSourceModel);
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
