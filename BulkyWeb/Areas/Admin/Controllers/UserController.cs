using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using BulkyWeb.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Areas.Admin.Controllers
{
   [Area("Admin")]
   [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        

        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoleManagment(string userId)
        {
            string RoleID = _db.UserRoles.FirstOrDefault(u => u.UserId == userId).RoleId;

            RoleManagmentVM RoleVM = new RoleManagmentVM()
            {
                User = _db.ApplicationUsers.Include(u => u.Company).FirstOrDefault(u => u.Id == userId),
                RoleList = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CompanyList = _db.Companies.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            RoleVM.User.Role = _db.Roles.FirstOrDefault(u => u.Id == RoleID).Name;
            return View(RoleVM);
        }

        [HttpPost]
        public IActionResult RoleManagment(RoleManagmentVM roleManagmentVM)
        {
            string RoleID = _db.UserRoles.FirstOrDefault(u => u.UserId == roleManagmentVM.User.Id).RoleId;
            string oldRole = _db.Roles.FirstOrDefault(u => u.Id == RoleID).Name;

            if (!(roleManagmentVM.User.Role == RoleID))
            {
                var applicationUser = _db.ApplicationUsers.First(u => u.Id == roleManagmentVM.User.Id);
                if(roleManagmentVM.User.Role == SD.Role_Company)
                {
                    applicationUser.CompanyId = roleManagmentVM.User.CompanyId;
                }
                if (oldRole == SD.Role_Company) 
                {
                    applicationUser.CompanyId = null;
                }

                var role = _db.Roles.FirstOrDefault(u => u.Id == roleManagmentVM.User.Role).Name;

                _userManager.AddToRoleAsync(applicationUser, role).GetAwaiter().GetResult();
                _userManager.RemoveFromRoleAsync(applicationUser,oldRole).GetAwaiter().GetResult();

                _db.SaveChanges();

                TempData["success"] = "Rola użytkownika została zmieniona";

            }

           

            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            var objUserList = _db.ApplicationUsers.Include(u=>u.Company).ToList();

            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var item in objUserList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == item.Id).RoleId;
                item.Role = roles.FirstOrDefault(u=>u.Id==roleId).Name;
                 
                if(item.Company==null)
                {
                    item.Company = new Company
                    {
                        Name = ""
                    };
                }
            }

            return Json(new {data= objUserList });
        }


        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id) 
        {
           var objFromDb = _db.ApplicationUsers.First(u=>u.Id==id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Błąd podczas Blokowanie/Odblokowania" });
            }

            if (objFromDb.LockoutEnd!=null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else 
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Blokowanie/Odblokowanie zakończone sukcesem" });
        }

      
        #endregion
    }
}
