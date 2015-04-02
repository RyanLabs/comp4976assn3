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
    public class HIVMedsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: HIVMeds
        public async Task<ActionResult> Index()
        {
            return View(await db.HivMedsModels.ToListAsync());
        }

        // GET: HIVMeds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIVMedsModel hIVMedsModel = await db.HivMedsModels.FindAsync(id);
            if (hIVMedsModel == null)
            {
                return HttpNotFound();
            }
            return View(hIVMedsModel);
        }

        // GET: HIVMeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIVMeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HIVMedsId,HIVMeds")] HIVMedsModel hIVMedsModel)
        {
            if (ModelState.IsValid)
            {
                db.HivMedsModels.Add(hIVMedsModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hIVMedsModel);
        }

        // GET: HIVMeds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIVMedsModel hIVMedsModel = await db.HivMedsModels.FindAsync(id);
            if (hIVMedsModel == null)
            {
                return HttpNotFound();
            }
            return View(hIVMedsModel);
        }

        // POST: HIVMeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HIVMedsId,HIVMeds")] HIVMedsModel hIVMedsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hIVMedsModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hIVMedsModel);
        }

        // GET: HIVMeds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIVMedsModel hIVMedsModel = await db.HivMedsModels.FindAsync(id);
            if (hIVMedsModel == null)
            {
                return HttpNotFound();
            }
            return View(hIVMedsModel);
        }

        // POST: HIVMeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HIVMedsModel hIVMedsModel = await db.HivMedsModels.FindAsync(id);
            db.HivMedsModels.Remove(hIVMedsModel);
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
