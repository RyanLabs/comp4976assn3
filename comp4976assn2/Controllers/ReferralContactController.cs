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
    public class ReferralContactController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ReferralContact
        public async Task<ActionResult> Index()
        {
            return View(await db.ReferralContactModels.ToListAsync());
        }

        // GET: ReferralContact/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralContactModel referralContactModel = await db.ReferralContactModels.FindAsync(id);
            if (referralContactModel == null)
            {
                return HttpNotFound();
            }
            return View(referralContactModel);
        }

        // GET: ReferralContact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferralContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReferralContactId,ReferralContact")] ReferralContactModel referralContactModel)
        {
            if (ModelState.IsValid)
            {
                db.ReferralContactModels.Add(referralContactModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(referralContactModel);
        }

        // GET: ReferralContact/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralContactModel referralContactModel = await db.ReferralContactModels.FindAsync(id);
            if (referralContactModel == null)
            {
                return HttpNotFound();
            }
            return View(referralContactModel);
        }

        // POST: ReferralContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReferralContactId,ReferralContact")] ReferralContactModel referralContactModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referralContactModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(referralContactModel);
        }

        // GET: ReferralContact/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralContactModel referralContactModel = await db.ReferralContactModels.FindAsync(id);
            if (referralContactModel == null)
            {
                return HttpNotFound();
            }
            return View(referralContactModel);
        }

        // POST: ReferralContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReferralContactModel referralContactModel = await db.ReferralContactModels.FindAsync(id);
            db.ReferralContactModels.Remove(referralContactModel);
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
