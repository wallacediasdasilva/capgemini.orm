using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Domain.Interface
{
    public interface IClassesRepository
    {
        IEnumerable<Classes> ListAll();
        Classes Create(Classes classes);
        Classes Update(int id, Classes classes);
        void Delete(int id);
        void Patch(int id, Classes classes);
        void Relashionship(Registration registration);
    }
}
