using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Application.App.Interface
{
    public interface IClassesApplication
    {
        IEnumerable<Classes> ListAll();
        Classes CreateStudent(Classes student);
        Classes UpdateStudent(int id, Classes student);
        void DeleteStudent(int id);
        void Patch(int id, Classes classes);
        void Relashionship(Registration registration);
    }
}
