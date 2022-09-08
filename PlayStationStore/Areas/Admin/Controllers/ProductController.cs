using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayStationStore.DataAccess;
using PlayStationStore.DataAccess.Repository;
using PlayStationStore.DataAccess.Repository.IRepository;
using PlayStationStore.Models;
using PlayStationStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayStationStore.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProduct = _unitOfWork.Product.GetAll();

            return View(objProduct);
        }

        
        //public IActionResult Create()
        //{
        //   // IEnumerable<Category> objRe = _dbContext.Categories;

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Product obj)
        //{
        //    //if(obj.Name==obj.DisplayOrder.ToString())
        //    //{
        //    //    ModelState.AddModelError("CustomError", "Name and DisplayOrder can't be Same");
        //    //    //You can even append to existing error
        //    //   // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
        //    //}
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Add(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product created successfully.";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
            
        //}

        public IActionResult UpSert(int? id)
        {

            ProductVM productVm = new ProductVM
            {
                product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            //Product prodct = new Product();
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString()
            //    });
            //IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
            //    u=>new SelectListItem
            //    {
            //        Text=u.Name,
            //        Value=u.Id.ToString()
            //    });
            if (id == null || id == 0)
            {
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(productVm);
            }
            else
            {

            }
            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Product obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("CustomError", "Name and DisplayOrder can't be Same");
            //    //You can even append to existing error
            //    // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubmit(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (obj==null)
            {
                return NotFound();
                //You can even append to existing error
                // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType deleted successfully.";
            return RedirectToAction("Index");
            
          

        }
    }
}
