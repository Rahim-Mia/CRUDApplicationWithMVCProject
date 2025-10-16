using AspDotNetCoreMVCExample.DAL.Models;
using AspDotNetCoreMVCExample.Repositories;

namespace AspDotNetCoreMVCExample.ApplicationLayer.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        void Save();

    }
}
