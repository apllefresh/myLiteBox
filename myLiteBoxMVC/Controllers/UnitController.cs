﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using myLiteBoxMVC.Models;

namespace myLiteBoxMVC.Controllers
{
    public class UnitController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Unit
        public async Task<ActionResult> Index()
        {
            return View(await db.Units.Where(u=> u.isActive == true).ToListAsync());
        }

       
        // GET: Unit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Unit unit)
        {
            unit.isActive = true;
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: Unit/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Unit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,isActive")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: Unit/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Unit unit = await db.Units.FindAsync(id);
            //db.Units.Remove(unit);
            unit.isActive = false;
            db.Entry(unit).State = EntityState.Modified;
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
