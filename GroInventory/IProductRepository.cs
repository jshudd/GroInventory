using System;
using System.Collections.Generic;
using GroInventory.Models;

namespace GroInventory
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);
        public void UpdateProduct(Product product);
        public void InsertProduct(Product productToInsert);
        public IEnumerable<Department> GetDepartments();
        public Product AssignDepartmentsList();
        //public void AssignStaticDeptList();
        public void DeleteProduct(Product product);
        //Search Bar below
        public IEnumerable<Product> SearchProduct(string search);
        //public IEnumerable<Product> SearchUPC(string search);
    }
}