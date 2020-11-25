using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Domain.Interface
{
    public interface IStudentRepository
    {
        IEnumerable<Student> ListAll();

        Student CreateStudent(Student student);
        Student UpdateStudent(int id, Student student);
        void DeleteStudent(int id);
        void Patch(int id, Student student);
    }
}
