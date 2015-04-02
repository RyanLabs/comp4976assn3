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
    public class AbuserRelationshipController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: AbuserRelationship
        public async Task<ActionResult> Index()
        {
            return View(await db.AbuserRelationshipModels.ToListAsync());
        }

        // GET: AbuserRelationship/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationshipModel abuserRelationshipModel = await db.AbuserRelationshipModels.FindAsync(id);
            if (abuserRelationshipModel == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationshipModel);
        }

        // GET: AbuserRelationship/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbuserRelationship/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AbuserRelationshipId,AbuserRelationship")] AbuserRelationshipModel abuserRelationshipModel)
        {
            if (ModelState.IsValid)
            {
                db.AbuserRelationshipModels.Add(abuserRelationshipModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(abuserRelationshipModel);
        }

        // GET: AbuserRelationship/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationshipModel abuserRelationshipModel = await db.AbuserRelationshipModels.FindAsync(id);
            if (abuserRelationshipModel == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationshipModel);
        }

        // POST: AbuserRelationship/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AbuserRelationshipId,AbuserRelationship")] AbuserRelationshipModel abuserRelationshipModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abuserRelationshipModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(abuserRelationshipModel);
        }

        // GET: AbuserRelationship/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationshipModel abuserRelationshipModel = await db.AbuserRelationshipModels.FindAsync(id);
            if (abuserRelationshipModel == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationshipModel);
        }

        // POST: AbuserRelationship/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AbuserRelationshipModel abuserRelationshipModel = await db.AbuserRelationshipModels.FindAsync(id);
            db.AbuserRelationshipModels.Remove(abuserRelationshipModel);
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
