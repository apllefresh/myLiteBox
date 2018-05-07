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
    public class SertificationController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Sertification
        public async Task<ActionResult> Index()
        {
            List<ListSertificationModel> list = new List<ListSertificationModel>();
            List<Manufacturer> mans = new List<Manufacturer>();
            mans = db.Manufacturers.ToList();

            foreach (var m in await db.Sertifications.ToListAsync())
            {
                list.Add(new ListSertificationModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    dateStart = m.dateStart.Date,
                    dateEnd = m.dateEnd.Date,
                    dateReg = m.dateReg.Date,
                    manufacturer = mans.Where(d => d.Id == m.ManufacturerId).Select(d => d.Name).First()
                });
            }
            return View(list);
           // return View(await db.Sertifications.ToListAsync());
        }

        // GET: Sertification/Create
        public ActionResult Create()
        {
            CreateSertificationModel model;
            model = new CreateSertificationModel
            {
                manufacturers = db.Manufacturers.ToList(),
                dateStart = DateTime.Now.Date,
                dateEnd = DateTime.Now.Date,
                dateReg = DateTime.Now.Date
            };
            return View(model);
        }

        // POST: Sertification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSertificationModel model)
        {
            if (ModelState.IsValid)
            {
                Sertification sert = new Sertification()
                {
                    Name = model.Name,
                    dateStart = model.dateStart,
                    dateEnd = model.dateEnd,
                    dateReg = model.dateReg,
                    ManufacturerId = model.ManufacturerId
                };

                db.Sertifications.Add(sert);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Sertification/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sertification sert = await db.Sertifications.FindAsync(id);
            if (sert == null)
            {
                return HttpNotFound();
            }
            Manufacturer _man = db.Manufacturers.Where(d => d.Id == sert.ManufacturerId).First();
            EditSertificationModel model = new EditSertificationModel()
            {
                Id = sert.Id,
                Name = sert.Name,
                dateStart = sert.dateStart.Date,
                dateEnd = sert.dateEnd.Date,
                dateReg = sert.dateReg.Date,

                ManufacturerId = sert.ManufacturerId,
                man = _man,
                manufacturers = db.Manufacturers.Distinct().ToList()
            };
            return View(model);
        }

        // POST: Sertification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditSertificationModel model)
        {
            if (ModelState.IsValid)
            {
                Sertification sert = await db.Sertifications.FindAsync(model.Id);
                if (sert != null)
                {
                    sert.Name = model.Name;
                    sert.dateStart = model.dateStart;
                    sert.dateEnd = model.dateEnd;
                    sert.dateReg = model.dateReg;
                    sert.ManufacturerId = model.ManufacturerId;
                    db.Entry(sert).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else return View(model);
            }
            return View(model);
        }

        // GET: Sertification/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sertification sertification = await db.Sertifications.FindAsync(id);
            if (sertification == null)
            {
                return HttpNotFound();
            }
            return View(sertification);
        }

        // POST: Sertification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sertification sertification = await db.Sertifications.FindAsync(id);
            db.Sertifications.Remove(sertification);
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
