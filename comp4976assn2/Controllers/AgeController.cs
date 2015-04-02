﻿using System;
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
    public class AgeController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Age
        public async Task<ActionResult> Index()
        {
            return View(await db.AgeModels.ToListAsync());
        }

        // GET: Age/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeModel ageModel = await db.AgeModels.FindAsync(id);
            if (ageModel == null)
            {
                return HttpNotFound();
            }
            return View(ageModel);
        }

        // GET: Age/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Age/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AgeId,Age")] AgeModel ageModel)
        {
            if (ModelState.IsValid)
            {
                db.AgeModels.Add(ageModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ageModel);
        }

        // GET: Age/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeModel ageModel = await db.AgeModels.FindAsync(id);
            if (ageModel == null)
            {
                return HttpNotFound();
            }
            return View(ageModel);
        }

        // POST: Age/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AgeId,Age")] AgeModel ageModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ageModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ageModel);
        }

        // GET: Age/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeModel ageModel = await db.AgeModels.FindAsync(id);
            if (ageModel == null)
            {
                return HttpNotFound();
            }
            return View(ageModel);
        }

        // POST: Age/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AgeModel ageModel = await db.AgeModels.FindAsync(id);
            db.AgeModels.Remove(ageModel);
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
