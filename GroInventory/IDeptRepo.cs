using System;
using GroInventory.Models;
using System.Collections.Generic;

namespace GroInventory
{
    public interface IDeptRepo
    {
        public void DeleteDept(Department dept);
        public IEnumerable<Department> GetDepartments();
        public Department GetDept(int id);
        public void InsertDept(Department deptToInsert);
        public void UpdateDept(Department dept);
    }
}

