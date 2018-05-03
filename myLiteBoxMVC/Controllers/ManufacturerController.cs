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
    public class ManufacturerController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Manufacturer
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await db.Manufacturers.ToListAsync());
        }

        [HttpPost]
        public JsonResult Country(string Prefix)
        {
            //Note : you can bind same list from database  
            List<string> ObjList = db.Manufacturers.Select(c => c.Country).ToList();
            
            //Searching records from list using LINQ query  
            var CountryList = (from N in ObjList
                            where N.StartsWith(Prefix)
                            select new { N }).Distinct();
            return Json(CountryList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Subject(string Prefix)
        {
            //Note : you can bind same list from database  
            List<string> ObjList = db.Manufacturers.Select(c => c.Subject).ToList();

            //Searching records from list using LINQ query  
            var SubjectList = (from N in ObjList
                               where N.StartsWith(Prefix)
                               select new { N }).Distinct();
            return Json(SubjectList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Distrinct(string Prefix)
        {
            //Note : you can bind same list from database  
            List<string> ObjList = db.Manufacturers.Select(c => c.Distrinct).ToList();

            //Searching records from list using LINQ query  
            var DistrinctList = (from N in ObjList
                               where N.StartsWith(Prefix)
                                 select new { N }).Distinct();
            return Json(DistrinctList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult City(string Prefix)
        {
            //Note : you can bind same list from database  
            List<string> ObjList = db.Manufacturers.Select(c => c.City).ToList();

            //Searching records from list using LINQ query  
            var CityList = (from N in ObjList
                               where N.StartsWith(Prefix)
                            select new { N }).Distinct();
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
        //// GET: Manufacturer/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
        //    if (manufacturer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(manufacturer);
        //}

        // GET: Manufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manufacturer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,INN,Country,Subject,Distrinct,City,Street,House,ZipCode")] Manufacturer manufacturer)
        {
            manufacturer.isActive = true;
            if (ModelState.IsValid)
            {
                db.Manufacturers.Add(manufacturer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: Manufacturer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,INN,Country,Subject,Distrinct,City,Street,House,ZipCode,isActive")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: Manufacturer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            //db.Manufacturers.Remove(manufacturer);
            manufacturer.isActive = false;
            db.Entry(manufacturer).State = EntityState.Modified;
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
