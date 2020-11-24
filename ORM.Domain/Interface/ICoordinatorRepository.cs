using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Domain.Interface
{
    public interface ICoordinatorRepository
    {
        IEnumerable<Coordinator> ListAll();
        Coordinator Create(Coordinator coordinator);
        Coordinator Update(int id, Coordinator coordinator);
        void Delete(int id);
    }
}
