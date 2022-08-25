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

        public long UPCPLU { get; set; }
        public string ProductName { get; set; }
        public long WarehouseCode { get; set; }
        public int DeptID { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public bool OnSale { get; set; }
        public bool PerPound { get; set; } = false;
        public double CaseCost { get; set; }
        public int LikeCodeID { get; set; }
        public int UnitsPerCase { get; set; }
        public double CurrentInventory { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<LikeCode> LikeCodes { get; set; }
        public double CurrentPrice
        {
            get
            {
                return (this.OnSale) ? this.SalePrice : this.Price;
            }
        }
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
        public string ConvertedCurrentPrice
        {
            get
            {
                return (this.CurrentPrice < 1) ? (this.CurrentPrice * 100) + "¢" : "$" + this.CurrentPrice.ToString("N");
            }
        }
        public string ConvertedProfit
        {
            get
            {
                return (this.Profit < 1 && this.Profit > 0) ? Math.Round((this.Profit * 100), 0) + "¢" : "$" + Math.Round(this.Profit, 2).ToString("N");
            }
        }
        public string DeptName
        {
            get
            {
                return Department.DeptList.ElementAt(DeptID - 1).DeptName;
            }
        }
        public double Profit
        {
            get
            {
                return ((this.CurrentPrice - (this.CaseCost/this.UnitsPerCase)) / (this.CaseCost/this.UnitsPerCase)) * 100;
            }
        }
        public string LikeCodeName
        {
            get
            {
                return LikeCode.LikeCodeList.ElementAt(LikeCodeID - 1).LikeCodeName;
            }
        }
    }
}

