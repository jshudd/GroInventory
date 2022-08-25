using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using GroInventory.Models;

namespace GroInventory
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Product AssignDepartmentsList()
        {
            var deptList = GetDepartments();
            var product = new Product();
            product.Departments = deptList;

            return product;
        }
        public void AssignLikeCodeList(Product product)
        {
            product.LikeCodes = GetLikeCodes();
        }
        public void DeleteProduct(Product product)
        {
            /*_conn.Execute("DELETE FROM REVIEWS WHERE UPCPLU = @upcplu;",
                new { upcplu = product.UPCPLU });
            _conn.Execute("DELETE FROM Sales WHERE UPCPLU = @upcplu;",
                new { upcplu = product.UPCPLU });*/
            _conn.Execute("DELETE FROM products WHERE UPCPLU = @upcplu;",
                new { upcplu = product.UPCPLU });
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }
        public IEnumerable<Department> GetDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }
        public IEnumerable<LikeCode> GetLikeCodes()
        {
            return _conn.Query<LikeCode>("SELECT * FROM likeCodes;");
        }
        public Product GetProduct(int upcplu)
        {
            return (Product)_conn.QuerySingle<Product>("SELECT * FROM hudds.products WHERE UPCPLU = @upcplu;",
                new { upcplu = upcplu });
        }
        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (UPCPLU, PRODUCTNAME, WAREHOUSECODE, PRICE, SALEPRICE, ONSALE, UNITSPERCASE, CASECOST, DEPTID, CURRENTINVENTORY,PERPOUND) VALUES (@upcplu, @name, @warehousecode, @price, @saleprice, @onsale, @unitspercase, @casecost, @deptid, @currentinventory, @perpound);",
                new
                {
                    upcplu = productToInsert.UPCPLU,
                    name = productToInsert.ProductName,
                    warehousecode = productToInsert.WarehouseCode,
                    price = productToInsert.Price,
                    saleprice = productToInsert.SalePrice,
                    onsale = productToInsert.OnSale,
                    unitspercase = productToInsert.UnitsPerCase,
                    casecost = productToInsert.CaseCost,
                    deptid = productToInsert.DeptID,
                    currentinventory = productToInsert.CurrentInventory,
                    perpound = productToInsert.PerPound
                });
        }
        //Search Bar
        public IEnumerable<Product> SearchProduct(string search)
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE productname LIKE @name OR UPCPLU LIKE @upcplu;",
                new { name = "%" + search + "%", upcplu = "%" + search + "%" });
        }
        public void UpdateProduct(Product product)
        {
            //_conn.Execute("UPDATE products SET ProductName = @name, WarehouseCode = @warehousecode, Price = @price, SalePrice = @saleprice, OnSale = @onsale, UnitsPerCase = @unitspercase, CaseCost = @casecost, DeptID = @deptid, CurrentInventory = @currentinventory WHERE UPC = @upc;",
            //    new {
            //        name = product.ProductName,
            //        warehousecode = product.WarehouseCode,
            //        price = product.Price,
            //        saleprice = product.SalePrice,
            //        onsale = product.OnSale,
            //        unitspercase = product.UnitsPerCase,
            //        casecost = product.CaseCost,
            //        deptid = product.DeptID,
            //        currentinventory = product.CurrentInventory,
            //        upc = product.UPC });

            _conn.Execute("UPDATE hudds.products SET ProductName = @name, WarehouseCode = @warehousecode, DeptID = @deptID, Price = @price, SalePrice = @saleprice, OnSale = @onsale, UnitsPerCase = @unitspercase, CaseCost = @casecost, CurrentInventory = @currentinventory, PerPound = @perpound WHERE UPCPLU = @upcplu;",
                new
                {
                    name = product.ProductName,
                    warehousecode = product.WarehouseCode,
                    deptID = product.DeptID,
                    price = product.Price,
                    saleprice = product.SalePrice,
                    onsale = product.OnSale,
                    unitspercase = product.UnitsPerCase,
                    casecost = product.CaseCost,
                    currentinventory = product.CurrentInventory,
                    upcplu = product.UPCPLU,
                    perpound = product.PerPound
                });
        }
        }
}
