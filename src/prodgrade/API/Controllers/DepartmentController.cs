using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
   
    public class DepartmentController : MainApiController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DepartmentStatic.getAllDepartment());
        }

        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            return Ok(DepartmentStatic.getDepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(Department department)
        {
            return Ok(DepartmentStatic.InsertDepartment(department));
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, Department department)
        {
            return Ok(DepartmentStatic.UpdateDepartment(code,department));
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(DepartmentStatic.DeleteDepartment(code));
        }
    }

    public static class DepartmentStatic {
        private static List<Department> Alldepartment { get; set; } = new List<Department>();

        public static Department InsertDepartment (Department department)
        {
            Alldepartment.Add(department);
            return department;
        }

        public static List<Department> getAllDepartment()
        {
            return Alldepartment;
        }

        public static Department getDepartment(string code)
        {
            return Alldepartment.FirstOrDefault(x => x.code == code);
        }

        public static Department UpdateDepartment(string code, Department department)
        {
            Department result = new Department();
            foreach (var aDepartment in Alldepartment)
            {
                if (code == aDepartment.code)
                {
                    aDepartment.name = department.name;
                    result = aDepartment;
                }
            }
            return result;

        }
        public static Department DeleteDepartment(string code)
        {
            var department = Alldepartment.FirstOrDefault(x => x.code == code);

            Alldepartment = Alldepartment.Where(x => x.code != code).ToList();
            return department;

        }


        }
}
