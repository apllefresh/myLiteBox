using System;
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
    public class NDSController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: NDS
        public async Task<ActionResult> Index()
        {
            return View(await db.NDS.Where(n=> n.isActive == true).ToListAsync());
        }

        // GET: NDS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NDS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Value")] NDS nDS)
        {
            nDS.isActive = true;
            if (ModelState.IsValid)
            {
                db.NDS.Add(nDS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nDS);
        }

        // GET: NDS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDS nDS = await db.NDS.FindAsync(id);
            if (nDS == null)
            {
                return HttpNotFound();
            }
            return View(nDS);
        }

        // POST: NDS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Value,isActive")] NDS nDS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nDS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nDS);
        }

        // GET: NDS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDS nDS = await db.NDS.FindAsync(id);
            if (nDS == null)
            {
                return HttpNotFound();
            }
            return View(nDS);
        }

        // POST: NDS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NDS nDS = await db.NDS.FindAsync(id);
            //db.NDS.Remove(nDS);
            nDS.isActive = false;
            db.Entry(nDS).State = EntityState.Modified;
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
