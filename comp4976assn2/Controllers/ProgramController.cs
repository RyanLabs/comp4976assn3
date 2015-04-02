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
    public class ProgramController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Program
        public async Task<ActionResult> Index()
        {
            return View(await db.ProgramModels.ToListAsync());
        }

        // GET: Program/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramModel programModel = await db.ProgramModels.FindAsync(id);
            if (programModel == null)
            {
                return HttpNotFound();
            }
            return View(programModel);
        }

        // GET: Program/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Program/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProgramId,Program")] ProgramModel programModel)
        {
            if (ModelState.IsValid)
            {
                db.ProgramModels.Add(programModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(programModel);
        }

        // GET: Program/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramModel programModel = await db.ProgramModels.FindAsync(id);
            if (programModel == null)
            {
                return HttpNotFound();
            }
            return View(programModel);
        }

        // POST: Program/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProgramId,Program")] ProgramModel programModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(programModel);
        }

        // GET: Program/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramModel programModel = await db.ProgramModels.FindAsync(id);
            if (programModel == null)
            {
                return HttpNotFound();
            }
            return View(programModel);
        }

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProgramModel programModel = await db.ProgramModels.FindAsync(id);
            db.ProgramModels.Remove(programModel);
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
