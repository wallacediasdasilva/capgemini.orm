using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Application.App.Interface
{
    public interface IStudentApplication
    {
        IEnumerable<Student> ListAll();
        Student Create(Student student);
        Student Update(int id, Student student);
        void Delete(int id);
        void Patch(int id, Student student);
    }
}
