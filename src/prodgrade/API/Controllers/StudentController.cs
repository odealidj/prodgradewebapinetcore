using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class StudentController : MainApiController
    {

        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentStatic.getAllStudent());
        }
        

        /*
        [HttpGet]
        //with query param
        public IActionResult GetAll([FromQuery] string name, [FromQuery] string email)
        {
            return Ok(StudentStatic.getAllStudent());
        }
        */

        [HttpGet("{email}")]
        public IActionResult GetByEmail(string email)
        {
            return Ok(StudentStatic.getStudent(email));
        }

        [HttpPost]
        //[FromForm] rest input form-data
        public IActionResult Insert([FromForm]Student student)
        {
            return Ok(StudentStatic.InsertStudent(student));
        }

        [HttpPut("{email}")]
        public IActionResult Update(string email, Student student)
        {
            return Ok(StudentStatic.UpdateStudent(email, student));
        }

        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            return Ok(StudentStatic.DeleteStudent (email));
        }
    }


    public static class StudentStatic
    {
        private static List<Student> Allstudent { get; set; } = new List<Student>();

        public static Student InsertStudent(Student student)
        {
            Allstudent.Add(student);
            return student;
        }

        public static List<Student> getAllStudent()
        {
            return Allstudent;
        }

        public static Student getStudent(string email)
        {
            return Allstudent.FirstOrDefault(x => x.email == email);
        }

        public static Student UpdateStudent(string email, Student student)
        {
            Student result = new Student();
            foreach (var aStudent in Allstudent)
            {
                if (email == aStudent.email)
                {
                    aStudent.name = student.name;
                    result = aStudent;
                }
            }
            return result;

        }
        public static Student DeleteStudent(string email)
        {
            var student = Allstudent.FirstOrDefault(x => x.email == email);

            Allstudent = Allstudent.Where(x => x.email != email).ToList();
            return student;

        }


    }
}
