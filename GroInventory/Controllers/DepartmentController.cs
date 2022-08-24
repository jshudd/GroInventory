using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroInventory.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroInventory.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDeptRepo repo;

        public DepartmentController(IDeptRepo repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult DeleteDept(Department dept)
        {
            repo.DeleteDept(dept);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            Department.DeptList = repo.GetDepartments();

            return View(Department.DeptList);
        }

        public IActionResult InsertDepartment()
        {
            //var prod = repo.AssignDepartmentsList();
            //repo.AssignLikeCodeList(prod);

            //return View(prod);

            var dept = new Department();

            return View(dept);
        }

        public IActionResult InsertDeptToDatabase(Department deptToInsert)
        {
            repo.InsertDept(deptToInsert);

            return RedirectToAction("Index");
        }


        public IActionResult ViewDepartment(int id)
        {
            var dept = repo.GetDept(id);

            return View(dept);
        }

        public IActionResult UpdateDepartment(int id)
        {
            var dept = repo.GetDept(id);

            if (dept == null)
            {
                return View("DepartmentNotFound");
            }

            return View(dept);
        }

        public IActionResult UpdateDeptToDatabase(Department dept)
        {
            repo.UpdateDept(dept);

            return RedirectToAction("ViewDepartment", new { id = dept.DeptID });
        }
    }
}

