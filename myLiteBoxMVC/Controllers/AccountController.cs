using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using myLiteBoxMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace myLiteBoxMVC.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        public ActionResult Index()
        {
            List<ListUser> list = new List<ListUser>();
            List<Department> deps = new List<Department>();
            using (ApplicationContext content = new ApplicationContext())
            {
                deps = content.Departments.ToList();
            }
            foreach (var u in UserManager.Users.ToList())
            {
                list.Add(new ListUser()
                {
                    UserName = u.UserName,
                    Department = deps.Where(d => d.Id == u.DepartmentId).Select(g => g.Name).First(),
                    Name = u.Name,
                    Roles = UserManager.GetRoles(u.Id).ToList().Count != 0 ? UserManager.GetRoles(u.Id).ToList()[0] : "No Role"
                });
            }
            return View(list);
        }


        public ActionResult Register()
        {
            RegisterModel model;
            using (ApplicationContext content = new ApplicationContext())
            {
                model = new RegisterModel
                {
                    departments = content.Departments.ToList(),
                    roles = RoleManager.Roles.ToList()
                };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    DepartmentId = model.DepartmentId,
                    Name = model.Name

                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ApplicationRole role = null;
                    foreach (ApplicationRole r in RoleManager.Roles)
                    {
                        if (r.Id == model.SelectedRoleId) role = r;
                    }
                    if (role != null) UserManager.AddToRole(user.Id, role.Name);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Account");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<ActionResult> Edit(string login)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(login);
            if (user != null)
            {
                EditModel model;
                using (ApplicationContext content = new ApplicationContext())
                {
                    Department _dep = null;
                    foreach (Department d in content.Departments)
                        if (d.Id == user.DepartmentId) _dep = d;
                    model = new EditModel
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Name = user.Name,
                        departments = content.Departments.ToList(),
                        dep = _dep,
                        roles = RoleManager.Roles.ToList(),
                        role = UserManager.GetRoles(user.Id).ToList().Count != 0 ? RoleManager.FindByName(UserManager.GetRoles(user.Id).ToList()[0]) : null
                    };
                }
                return View(model);

            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.DepartmentId = model.DepartmentId;
                user.UserName = model.UserName;
                user.Name = model.Name;
                if (model.role != null)
                {
                    string[] roles = UserManager.GetRoles(user.Id).ToArray();
                    await UserManager.RemoveFromRolesAsync(user.Id, roles);
                    await UserManager.AddToRoleAsync(user.Id, model.role.Name);
                }
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View(model);
        }
    }
}