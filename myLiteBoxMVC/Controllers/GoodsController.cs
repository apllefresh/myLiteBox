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
    public class GoodsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Goods
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewGoodsModel Index(string ean)
        {
            try
            {
                Good g = db.Goods.Where(r => r.Ean == ean).First();
                string _unit = db.Units.Where(r => r.Id == g.UnitId).First().Name;
                int _nds = db.NDS.Where(r => r.Id == g.NDSId).First().Value;
                string _group = db.Groups.Where(r => r.Id == g.GroupId).First().Name;
                string _dep = db.Departments.Where(r => r.Id == g.DepartmentId).First().Name;
                SGood sg = db.SGoods.Where(r => r.GoodId == g.Id).OrderByDescending(d => d.DateCreate).First();
                RPrice rp = db.RPrices.Where(r => r.GoodId == g.Id).OrderByDescending(d => d.DateCreate).First();

                GoodInf gi = db.GoodInfs.Where(r => r.GoodId == g.Id).First();
                Manufacturer man = db.Manufacturers.Where(r => r.Id == gi.ManufacturerId).First();

                var i = db.GoodInfs.ToList();
                var s = db.SGoods.ToList();
                ViewGoodsModel model = new ViewGoodsModel
                {
                    unit = _unit,
                    nds = _nds,
                    group = _group,
                    dep = _dep,
                    Name = sg.Name,
                    price = rp.price,
                    m_Name = man.Name,
                    adress = string.Join(", ", new string[] { man.Country, man.Subject, man.Distrinct, man.City, man.Street, man.House }),
                    DateCreateSGood = sg.DateCreate,
                    DateCreateRPrice = rp.DateCreate,

                    fat = gi.fat,
                    mult = gi.mult,
                    brutto = gi.brutto,
                    energy = gi.energy,
                    proteins = gi.proteins,
                    fats = gi.fats,
                    carbohydrates = gi.carbohydrates,
                    vitamins = gi.vitamins,
                    staff = gi.staff,
                    recomendations = gi.recomendations,
                    storage = gi.storage,
                    CreatorIdGoodInf = gi.CreatorId,
                    EditorIdGoodInf = gi.EditorId,
                    DateCreateGoodInf = gi.DateCreate,
                    DateEditGoodInf = gi.DateEdit
                };
                return model;
            }
            catch
            {
                
                return null;
            }
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Ean,GroupId,UnitId,NDSId,DepartmentId")] Good good)
        {
            if (ModelState.IsValid)
            {
                db.Goods.Add(good);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(good);
        }

        // GET: Goods/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = await db.Goods.FindAsync(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ean,GroupId,UnitId,NDSId,DepartmentId")] Good good)
        {
            if (ModelState.IsValid)
            {
                db.Entry(good).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(good);
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
