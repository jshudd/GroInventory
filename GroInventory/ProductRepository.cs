﻿using System;
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

        public Product GetProduct(int upcplu)
        {
            return (Product)_conn.QuerySingle<Product>("SELECT * FROM hudds.products WHERE UPCPLU = @upcplu;",
                new { upcplu = upcplu });
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

            _conn.Execute("UPDATE hudds.products SET ProductName = @name, WarehouseCode = @warehousecode, DeptID = @deptID, Price = @price, SalePrice = @saleprice, OnSale = @onsale, UnitsPerCase = @unitspercase, CaseCost = @casecost, CurrentInventory = @currentinventory WHERE UPCPLU = @upcplu;",
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
                    upcplu = product.UPCPLU
                });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (UPCPLU, PRODUCTNAME, WAREHOUSECODE, PRICE, SALEPRICE, ONSALE, UNITSPERCASE, CASECOST, DEPTID, CURRENTINVENTORY) VALUES (@upcplu, @name, @warehousecode, @price, @saleprice, @onsale, @unitspercase, @casecost, @deptid, @currentinventory);",
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
                    currentinventory = productToInsert.CurrentInventory
                });
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }

        public Product AssignDepartmentsList()
        {
            var deptList = GetDepartments();
            var product = new Product();
            product.Departments = deptList;

            return product;
        }

        //Not needed? Delete?
        //public void AssignStaticDeptList()
        //{
        //    Department.DeptList = GetDepartments();
        //}

        //Search Bar
        public IEnumerable<Product> SearchProduct(string search)
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE productname LIKE @name OR UPCPLU LIKE @upcplu;",
                new { name = "%" + search + "%", upcplu = "%" + search + "%" });
        }

        //public IEnumerable<Product> SearchUPC(string search)
        //{
        //    return _conn.Query<Product>("SELECT * FROM products WHERE upc LIKE @upc;",
        //        new { upc = "%" + search + "%" });
        //}        
    }
}
