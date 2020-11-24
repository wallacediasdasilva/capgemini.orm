using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Domain.Interface
{
    public interface IDisciplineRepository
    {
        IEnumerable<Discipline> ListAll();
        Discipline Create(Discipline discipline);
        Discipline Update(int id, Discipline discipline);
        void Delete(int id);
    }
}
