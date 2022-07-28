using System;
using System.Collections.Generic;
using System.Linq;

namespace GroInventory.Models
{
    public class Product
    {
        public Product()
        {
        }

        public int UPCPLU { get; set; }
        public string ProductName { get; set; }
        public int WarehouseCode { get; set; }
        public int DeptID { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public bool OnSale { get; set; }
        public double CaseCost { get; set; }
        public string LikeCodeID { get; set; }
        public int UnitsPerCase { get; set; }
        public double CurrentInventory { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public string ConvertedPrice
        {
            get
            {
                return (this.Price < 1) ? (this.Price * 100) + "¢" : "$" + this.Price.ToString("N");
            }
        }
        public string ConvertedSalePrice
        {
            get
            {
                return (this.SalePrice < 1) ? (this.SalePrice * 100) + "¢" : "$" + this.SalePrice.ToString("N");
            }
        }
        public string ConvertedCaseCost
        {
            get
            {
                return (this.CaseCost < 1) ? (this.CaseCost * 100) + "¢" : "$" + this.CaseCost.ToString("N");
            }
        }

        public string DeptName
        {
            get
            {
                return Department.DeptList.ElementAt(DeptID).DeptName;
            }
        }
    }
}

