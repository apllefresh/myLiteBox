using myLiteBoxMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace myLiteBoxMVC.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        public ActionResult Index()
        {
            List<ListRoleModel> list = new List<ListRoleModel>();
            foreach (ApplicationRole r in RoleManager.Roles)
            {
                list.Add(new ListRoleModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                });
            }
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(new ApplicationRole
                {
                    Name = model.Name,
                    Description = model.Description
                });
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            ApplicationRole role = null;
             foreach(ApplicationRole r in RoleManager.Roles)
            {
                 if (r.Id == id) role = r;
            }
            //ApplicationRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                return View( new EditRoleModel { Id = role.Id, Name = role.Name, Description = role.Description });
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole role = null;
                foreach (ApplicationRole r in RoleManager.Roles)
                {
                    if (r.Id == model.Id) role = r;
                }
                if (role != null)
                {
                    role.Description = model.Description;
                    role.Name = model.Name;
                    IdentityResult result = await RoleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Что-то пошло не так");
                    }
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(string id)
        {
            ApplicationRole role = null;
            foreach (ApplicationRole r in RoleManager.Roles)
            {
                if (r.Id == id) role = r;
            }
            if (role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}