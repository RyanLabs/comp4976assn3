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
    public class ServiceController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Service
        public async Task<ActionResult> Index()
        {
            return View(await db.ServiceModels.ToListAsync());
        }

        // GET: Service/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceModel serviceModel = await db.ServiceModels.FindAsync(id);
            if (serviceModel == null)
            {
                return HttpNotFound();
            }
            return View(serviceModel);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ServiceId,Service")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                db.ServiceModels.Add(serviceModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(serviceModel);
        }

        // GET: Service/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceModel serviceModel = await db.ServiceModels.FindAsync(id);
            if (serviceModel == null)
            {
                return HttpNotFound();
            }
            return View(serviceModel);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ServiceId,Service")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(serviceModel);
        }

        // GET: Service/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceModel serviceModel = await db.ServiceModels.FindAsync(id);
            if (serviceModel == null)
            {
                return HttpNotFound();
            }
            return View(serviceModel);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ServiceModel serviceModel = await db.ServiceModels.FindAsync(id);
            db.ServiceModels.Remove(serviceModel);
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
