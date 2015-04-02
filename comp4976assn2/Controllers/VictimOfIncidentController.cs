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
    public class VictimOfIncidentController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: VictimOfIncident
        public async Task<ActionResult> Index()
        {
            return View(await db.VictimOfIncidentModels.ToListAsync());
        }

        // GET: VictimOfIncident/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimOfIncidentModel victimOfIncidentModel = await db.VictimOfIncidentModels.FindAsync(id);
            if (victimOfIncidentModel == null)
            {
                return HttpNotFound();
            }
            return View(victimOfIncidentModel);
        }

        // GET: VictimOfIncident/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VictimOfIncident/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VictimOfIncidentId,VictimOfIncident")] VictimOfIncidentModel victimOfIncidentModel)
        {
            if (ModelState.IsValid)
            {
                db.VictimOfIncidentModels.Add(victimOfIncidentModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(victimOfIncidentModel);
        }

        // GET: VictimOfIncident/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimOfIncidentModel victimOfIncidentModel = await db.VictimOfIncidentModels.FindAsync(id);
            if (victimOfIncidentModel == null)
            {
                return HttpNotFound();
            }
            return View(victimOfIncidentModel);
        }

        // POST: VictimOfIncident/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VictimOfIncidentId,VictimOfIncident")] VictimOfIncidentModel victimOfIncidentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victimOfIncidentModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(victimOfIncidentModel);
        }

        // GET: VictimOfIncident/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimOfIncidentModel victimOfIncidentModel = await db.VictimOfIncidentModels.FindAsync(id);
            if (victimOfIncidentModel == null)
            {
                return HttpNotFound();
            }
            return View(victimOfIncidentModel);
        }

        // POST: VictimOfIncident/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VictimOfIncidentModel victimOfIncidentModel = await db.VictimOfIncidentModels.FindAsync(id);
            db.VictimOfIncidentModels.Remove(victimOfIncidentModel);
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
