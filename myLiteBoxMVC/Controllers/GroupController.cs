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
    public class GroupController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Groups
        public ActionResult Index()
        {

            List<ListGroupModel> list = new List<ListGroupModel>();
            List<Department> deps = new List<Department>();
                deps = db.Departments.ToList();
           
            foreach (var g in db.Groups.Where(g=> g.isActive == true).ToList())
            {
                list.Add(new ListGroupModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Department = deps.Where(d => d.Id == g.DepartmentId).Select(d => d.Name).First()
                });
            }
            return View(list);
           // return View(await db.Groups.ToListAsync());
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            CreateGroupModel model;
           
                model = new CreateGroupModel
                {
                    departments = db.Departments.Where(g => g.isActive == true).ToList()
                };
                return View(model);
           
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateGroupModel model)
        {
            if (ModelState.IsValid)
            {

                Group group = new Group()
                {
                    Name = model.Name,
                    DepartmentId = model.DepartmentId,
                    isActive = true
                };

                db.Groups.Add(group);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Groups/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            Department _dep = db.Departments.Where(d => d.Id == group.DepartmentId).First();
            EditGroupModel model = new EditGroupModel()
            {
                Id = group.Id,
                Name = group.Name,
                isActive = group.isActive,
                DepartmentId = group.DepartmentId,
                dep = _dep,
                departments = db.Departments.Where(g => g.isActive == true).Distinct().ToList()
            };
            return View(model);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditGroupModel model)
        {
            if (ModelState.IsValid)
            {
                Group group = await db.Groups.FindAsync(model.Id);
                if (group != null)
                {
                    group.Name = model.Name;
                    group.DepartmentId = model.DepartmentId;
                    db.Entry(group).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else return View(model);
            }

            return View(model);
        }

        // GET: Groups/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Group group = await db.Groups.FindAsync(id);
            //db.Groups.Remove(group);
            group.isActive = false;
            db.Entry(group).State = EntityState.Modified;
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
