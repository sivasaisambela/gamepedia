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
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverType = _unitOfWork.CoverType.GetAll();

            return View(objCoverType);
        }

        
        public IActionResult Create()
        {
           // IEnumerable<Category> objRe = _dbContext.Categories;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            //if(obj.Name==obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("CustomError", "Name and DisplayOrder can't be Same");
            //    //You can even append to existing error
            //   // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType created successfully.";
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
            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if(coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CoverType obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("CustomError", "Name and DisplayOrder can't be Same");
            //    //You can even append to existing error
            //    // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType updated successfully.";
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
            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubmit(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (obj==null)
            {
                return NotFound();
                //You can even append to existing error
                // ModelState.AddModelError("Name", "Name and DisplayOrder can't be Same");
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType deleted successfully.";
            return RedirectToAction("Index");
            
          

        }
    }
}
