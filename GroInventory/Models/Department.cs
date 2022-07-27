using System;
using System.Collections.Generic;

namespace GroInventory.Models
{
    public class Department
    {
        public string DeptName { get; set; }
        public int DeptID { get; set; }
        public static IEnumerable<Department> DeptList { get; set; }
    }
}

