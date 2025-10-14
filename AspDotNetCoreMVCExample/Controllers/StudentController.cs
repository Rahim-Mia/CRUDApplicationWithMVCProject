using AspDotNetCoreMVCExample.Data;
using AspDotNetCoreMVCExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCoreMVCExample.Controllers
{
    public class StudentController : Controller
    {
       
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name ="Abdur Rahim", Age = 30,Email = "rahim@gmail.com", Mobile = "019183838333",Gender = "Male"},
            new Student { Id = 2, Name ="Alamin mia", Age = 25,Email = "alamin@gmail.com", Mobile = "0191838383213",Gender = "Male"},
            new Student { Id = 3, Name ="Mehedi hasan", Age = 22,Email = "mehedi@gmail.com", Mobile = "019183832333",Gender = "Male"},
            new Student { Id = 4, Name ="Khadija akter", Age = 23,Email = "khadija@gmail.com", Mobile = "019183888333",Gender = "Female"},
        };
        
        public IActionResult Index()
        {
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);

            }
            student.Id = students.Count + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Student student = students.FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public IActionResult Edit(int id)
        {
            Student student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            var existingStudent = students.FirstOrDefault(x=>x.Id == student.Id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Age = student.Age;
            existingStudent.Mobile  = student.Mobile;
            existingStudent.Gender = student.Gender;

            return RedirectToAction("Index");
        }
        // Delete Method
        public IActionResult Delete(int id)
        {

            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {

            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null) return NotFound();
            students.Remove(student);
            return RedirectToAction("Index");
        }

    }
}
