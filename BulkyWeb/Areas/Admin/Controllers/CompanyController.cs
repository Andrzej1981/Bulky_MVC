﻿using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using BulkyWeb.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objCompanyList = _unitOfWork.Company.GetAll().ToList(); 


            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
           
            if(id==null || id ==0)
            {
                return View(new Company());
            }
            else
            {
                Company company = _unitOfWork.Company.Get(u=>u.Id == id); 
                return View(company);
            }
        }

   
        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
                        
            if (ModelState.IsValid)
            {
               

                if(companyObj.Id ==0)
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }

                
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index", "Company");
            }
            else
            {
                
                return View(companyObj);

            }

        }
        
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0) return NotFound();

        //    Company? category = _unitOfWork.Company.Get(c => c.Id == id);
        //    if (category == null) return NotFound();
        //    return View(category);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    Company? obj = _unitOfWork.Company.Get(c => c.Id == id);

        //    if (obj == null) return NotFound();

        //    _unitOfWork.Company.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Company deleted successfully";
        //    return RedirectToAction("Index", "Company");

        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            var objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new {data=objCompanyList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u=>u.Id==id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success=false,message="Error while deleting" });
            }

            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete succesfull" });
        }
        #endregion
    }
}
