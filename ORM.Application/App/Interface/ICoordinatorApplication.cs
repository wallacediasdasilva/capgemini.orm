using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Application.App.Interface
{
    public interface ICoordinatorApplication
    {
        IEnumerable<Coordinator> ListAll();
        Coordinator Create(Coordinator coordinator);
        Coordinator Update(int id, Coordinator coordinator);
        void Delete(int id);
    }
}
