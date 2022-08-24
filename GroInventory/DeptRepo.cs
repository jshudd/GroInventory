using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using GroInventory.Models;

namespace GroInventory
{
    public class DeptRepo : IDeptRepo
    {
        private readonly IDbConnection _conn;

        public DeptRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteDept(Department dept)
        {
            _conn.Execute("DELETE FROM hudds.departments WHERE DeptID = @deptID;",
                new { deptID = dept.DeptID });
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }

        public Department GetDept(int deptID)
        {
            return _conn.QuerySingle<Department>("SELECT * FROM hudds.departments WHERE DeptID = @deptID;",
                new { deptID = deptID });
        }

        public void InsertDept(Department deptToInsert)
        {
            _conn.Execute("INSERT INTO hudds.departments (DeptName) VALUES (@name);",
                new { name = deptToInsert.DeptName });
        }

        public void UpdateDept(Department dept)
        {
            _conn.Execute("UPDATE hudds.departments SET DeptName = @name WHERE DeptID = @deptID;",
                new { name = dept.DeptName, deptID = dept.DeptID });
        }
    }
}

