using System;
using System.Collections.Generic;
using GroInventory.Models;

namespace GroInventory
{
    public interface IProductRepository
    {
        public Product AssignDepartmentsList();
        public void AssignLikeCodeList(Product product);
        public void DeleteProduct(Product product);
        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Department> GetDepartments();
        public IEnumerable<LikeCode> GetLikeCodes();
        public Product GetProduct(int id);        
        public void InsertProduct(Product productToInsert);
        //Search Bar below
        public IEnumerable<Product> SearchProduct(string search);
        public void UpdateProduct(Product product);
    }
}