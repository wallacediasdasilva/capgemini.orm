using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Application.App.Interface
{
    public interface IDisciplineApplication
    {
        IEnumerable<Discipline> ListAll();
        Discipline Create(Discipline discipline);
        Discipline Update(int id, Discipline discipline);
        void Delete(int id);

    }
}
