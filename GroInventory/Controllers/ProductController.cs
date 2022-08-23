using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroInventory.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroInventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();

            Department.DeptList = repo.GetDepartments();
            LikeCode.LikeCodeList = repo.GetLikeCodes();

            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);

            Department.DeptList = repo.GetDepartments();
            LikeCode.LikeCodeList = repo.GetLikeCodes();

            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);

            if (prod == null)
            {
                return View("ProductNotFound");
            }

            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.UPCPLU });
        }

        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);

            return RedirectToAction("Index");
        }

        public IActionResult InsertProduct()
        {
            var prod = repo.AssignDepartmentsList();
            repo.AssignLikeCodeList(prod);

            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        //Search Bar
        public IActionResult Search(string searchString)
        {
            var search = repo.SearchProduct(searchString);

            return View(search);
        }

        //public IActionResult SearchUPC(string searchString)
        //{
        //    var search = repo.SearchUPC(searchString);

        //    return View(search);
        //}
    }
}

