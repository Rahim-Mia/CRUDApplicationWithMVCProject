using AspDotNetCoreMVCExample.Models;

namespace AspDotNetCoreMVCExample.Repositories
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
