using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Model;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IEmployeeRepository employeeOperation, IWebHostEnvironment hostingEnvironment)
         {
            _employeeRepository = employeeOperation;
            _hostingEnvironment = hostingEnvironment;
        }
  
        public ViewResult Index()
        {
            var mod= _employeeRepository.GetEmployees();
            return View(mod);
        }
        public JsonResult Details()
        {
            Employee EmpObj = _employeeRepository.GetEmployee(1);
            return Json(EmpObj);
        }

        public ObjectResult DetailsWithXMl()
        {
            Employee EmpObj = _employeeRepository.GetEmployee(1);
            return new ObjectResult(EmpObj);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeePath employee)
        {
            if (ModelState.IsValid)
            {
                string uFineNames = null;
                if(employee.ImagePaths!=null && employee.ImagePaths.Count>1)
                {
                    foreach (IFormFile ImagePath in employee.ImagePaths)
                    {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uFineNames = Guid.NewGuid().ToString() + "_" + ImagePath;
                        string filePath = Path.Combine(uploadsFolder, uFineNames);
                        ImagePath.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }
                Employee newobj = new Employee
                {
                    UserName = employee.UserName,
                    Department = employee.Department,
                    ImagePath = uFineNames,
                    FirstName = employee.FirstName,
                    Email = employee.Email
                   
                };
                _employeeRepository.AddEmp(newobj);
                return RedirectToAction("EmployeeViewList", new { id = newobj.PersonslId });
            }
            else
                return View();
        }
      
        public ViewResult EmployeeViewList(int id)
        {
            Employee employee2 = _employeeRepository.GetEmployee(id);
            if(employee2==null)
            {
                return View("ErrorNotFound");
            }
            HomeEmployeeViewListViewModels homeEmployeeViewListViewModels = new HomeEmployeeViewListViewModels()
            {
                employee = employee2,
                Title = "Employee Details  Pages"
            };
            //Employee EmpObj = _employeeRepository.GetEmployee(1);
            //ViewBag.Employee = EmpObj;
            //ViewBag.PageTitle = "Employee Deialss";
            //return View("../Employees/EmployeeViews", EmpObj);
            //return View("~/MyView/CustomsEmployyeViewList.cshtml", EmpObj);
            return View("EmployyeViewList", homeEmployeeViewListViewModels);
        }


        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Employee employee = _employeeRepository.GetEmployee(Id);
            if (employee == null)
            {
                return View("ErrorNotFound");
            }
            HomeEmployeeViewEditModel homeEmployeeViewEditModel = new HomeEmployeeViewEditModel()
            {
                   employee = employee,
                  Title = "Employee Edit Page",
            };

            return View(homeEmployeeViewEditModel);
        }

        [HttpPost]
        public IActionResult Edit(HomeEmployeeViewEditModel employeeViewEditModel)
        {
            if (ModelState.IsValid)
            {
                string uFineNames = employeeViewEditModel.employee.ImagePath;
                if (employeeViewEditModel.ImagePaths != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    if(!string.IsNullOrEmpty(uFineNames))
                    {
                        System.IO.File.Delete(uploadsFolder + uFineNames);
                    }
                    uFineNames = Guid.NewGuid().ToString() + "_" + employeeViewEditModel.ImagePaths.FileName;
                    string filePath = Path.Combine(uploadsFolder, uFineNames);
                    using (FileStream FS = new FileStream(filePath, FileMode.Create))
                    {
                        employeeViewEditModel.ImagePaths.CopyTo(FS);
                    }
                }
                Employee newobj = new Employee
                {
                    UserName = employeeViewEditModel.employee.UserName,
                    Department = employeeViewEditModel.employee.Department,
                    ImagePath = uFineNames,
                    FirstName = employeeViewEditModel.employee.FirstName,
                    Email = employeeViewEditModel.employee.Email,
                    PersonslId=employeeViewEditModel.employee.PersonslId
                    
                };
                _employeeRepository.Update(newobj);
                return RedirectToAction("EmployeeViewList", new { id = employeeViewEditModel.employee.PersonslId });
            }
            else
                return View();
        }
    }
}