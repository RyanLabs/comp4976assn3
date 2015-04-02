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
    public class MultiplePerpetratorsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: MultiplePerpetrators
        public async Task<ActionResult> Index()
        {
            return View(await db.MultiplePerpetratorsModels.ToListAsync());
        }

        // GET: MultiplePerpetrators/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetratorsModel multiplePerpetratorsModel = await db.MultiplePerpetratorsModels.FindAsync(id);
            if (multiplePerpetratorsModel == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetratorsModel);
        }

        // GET: MultiplePerpetrators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultiplePerpetrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MultiplePerpetratorsId,MultiplePerpetrators")] MultiplePerpetratorsModel multiplePerpetratorsModel)
        {
            if (ModelState.IsValid)
            {
                db.MultiplePerpetratorsModels.Add(multiplePerpetratorsModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(multiplePerpetratorsModel);
        }

        // GET: MultiplePerpetrators/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetratorsModel multiplePerpetratorsModel = await db.MultiplePerpetratorsModels.FindAsync(id);
            if (multiplePerpetratorsModel == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetratorsModel);
        }

        // POST: MultiplePerpetrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MultiplePerpetratorsId,MultiplePerpetrators")] MultiplePerpetratorsModel multiplePerpetratorsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multiplePerpetratorsModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(multiplePerpetratorsModel);
        }

        // GET: MultiplePerpetrators/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetratorsModel multiplePerpetratorsModel = await db.MultiplePerpetratorsModels.FindAsync(id);
            if (multiplePerpetratorsModel == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetratorsModel);
        }

        // POST: MultiplePerpetrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MultiplePerpetratorsModel multiplePerpetratorsModel = await db.MultiplePerpetratorsModels.FindAsync(id);
            db.MultiplePerpetratorsModels.Remove(multiplePerpetratorsModel);
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
