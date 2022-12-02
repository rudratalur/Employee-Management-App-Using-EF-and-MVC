using Microsoft.AspNetCore.Mvc;
using EmployeeDepartmentProject.DataAccess.Repository;
using EmployeeDepartmentProject.DataAccess.Repository.IRepository;
using EmployeeDepartmentProject.Models;

namespace WebAppProjectTrail2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var allDepartments = _unitOfWork.Department.GetAll();
            return View(allDepartments);
        }

        public IActionResult Details(int? id)
        {
            var department = _unitOfWork.Department.GetFirstOrDefault(c => c.DepartID == id);
            return View(department);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department deptObj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Add(deptObj);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit(int? departmentID)
        {
            if (departmentID == null || departmentID == 0)
            {
                return NotFound();
            }
            var departmentFirstOrDefault = _unitOfWork.Department.GetFirstOrDefault(c => c.DepartID == departmentID);
            //if (_unitOfWork.Department == null)
            //{
            //    return NotFound();
            //}
            return View(departmentFirstOrDefault);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult EditPost(Department deptObj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Update(deptObj);
                _unitOfWork.Save();
                //TempData["Success"] = "Edit is completed successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {

                return View(deptObj);
            }

        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var departmentFromDb = _unitOfWork.Department.GetFirstOrDefault(c => c.DepartID == id);
            if (departmentFromDb == null)
            {
                return NotFound();
            }
            return View(departmentFromDb);
        }
        [HttpPost]
        [ActionName("Delete")]
        // [ValidateAntiForgeryToken] bcause we dont have any text box
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Department.GetFirstOrDefault(c => c.DepartID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Department.Remove(obj);
            _unitOfWork.Save();
            //TempData["Success"] = "Deleted Successfully";
            return RedirectToAction(nameof(Index));
            //return View();
        }
    }

}
