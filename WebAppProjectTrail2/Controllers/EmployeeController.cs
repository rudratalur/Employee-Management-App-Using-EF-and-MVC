using EmployeeDepartmentProject.DataAccess.Data;
using EmployeeDepartmentProject.DataAccess.Repository.IRepository;
using EmployeeDepartmentProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebAppProjectTrail2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmployeeDepartmentDbContext _dbContext;
        
        public  EmployeeController(IUnitOfWork unitOfWork, EmployeeDepartmentDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var alldata = _dbContext.Employees.Include(c => c.Departments);
            return View(alldata);
        }

        //[HttpGet]
        //public async Task<IActionResult> Index(string Empsearch)
        //{
        //    ViewBag["Getemployeedetails"] = Empsearch;

        //    var empquery = from x in _dbContext.Employees select x;
        //    if (!String.IsNullOrEmpty(Empsearch))
        //    {
        //        empquery = empquery.Where(x => x.EmployeeName.Contains(Empsearch)); //|| x.EmployeeId.Contains(Empsearch)
        //    }
        //    return View(await empquery.AsNoTracking().ToListAsync());
        //}

        public IActionResult Create()
        {
            ViewBag.Department = GetDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee empObj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Add(empObj);
                _unitOfWork.Save();
                TempData["Success"] = "Employee Field is successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                
                return View();
            }

        }

        public IActionResult Edit(int? employeeId)
        {
            if (employeeId == null || employeeId == 0)
            {
                return NotFound();
            }
            ViewBag.Department = GetDepartments();
            var employeeFirstOrDefault = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmployeeId == employeeId);
            if(employeeFirstOrDefault==null)
            {
                return NotFound();
            }
            return View(employeeFirstOrDefault);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult EditPost(Employee empObj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Update(empObj);
                _unitOfWork.Save();
                TempData["Success"] = "Edit is completed successfully";
                return RedirectToAction(nameof(Index));
            }
               
                return View(empObj);
        }

        public IActionResult Delete(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeFromDb = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmployeeId == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }
        [HttpPost]
        [ActionName("Delete")]
        // [ValidateAntiForgeryToken] bcause we dont have any text box
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmployeeId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
        private List<SelectListItem> GetDepartments()
        {
            var lstDepts = new List<SelectListItem>();

            var depts = _unitOfWork.Department.GetAll();
            lstDepts = depts.Select(dp => new SelectListItem()
            {
                Value = dp.DepartID.ToString(),
                Text = dp.DepartName
            }).ToList();

            var defDept = new SelectListItem()
            {
                Value = "",
                Text = "---Select Department---"
            };

            lstDepts.Insert(0, defDept);
            return lstDepts;
        }

    }
}
