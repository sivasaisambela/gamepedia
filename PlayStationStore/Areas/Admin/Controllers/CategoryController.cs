using Microsoft.AspNetCore.Mvc;
using PlayStationStore.DataAccess;
using PlayStationStore.DataAccess.Repository;
using PlayStationStore.DataAccess.Repository.IRepository;
using PlayStationStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayStationStore.Controllers
{
   [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objRe = _unitOfWork.Category.GetAll();

            return View(objRe);
        }

        
        public IActionResult Create()
        {
           // IEnumerable<Category> objRe = _dbContext.Categories;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and DisplayOrder can't be Same");
                //You can even append to existing error
               // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if(categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and DisplayOrder can't be Same");
                //You can even append to existing error
                // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully.";
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
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubmit(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if (obj==null)
            {
                return NotFound();
                //You can even append to existing error
                // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");
            
          

        }
    }
}
