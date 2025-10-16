using AspDotNetCoreMVCExample.ApplicationLayer.Repositories;
using AspDotNetCoreMVCExample.Data;
using AspDotNetCoreMVCExample.DAL.Models;

namespace AspDotNetCoreMVCExample.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            Save();
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            _context.Students.Remove(student);
            Save();
            
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id) ?? new Student();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = GetStudentById(student.Id);
            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Email = student.Email;
            existingStudent.Mobile = student.Mobile;
            existingStudent.Gender = student.Gender;
            Save();

        }
        
    }
}
