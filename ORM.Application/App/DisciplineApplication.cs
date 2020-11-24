using ORM.Application.App.Interface;
using ORM.Domain.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Application.App
{
    public class DisciplineApplication : IDisciplineApplication
    {
        private readonly IDisciplineRepository _disciplineRepository;

        public DisciplineApplication(IDisciplineRepository disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }

        public Discipline Create(Discipline discipline)
        {
            return _disciplineRepository.Create(discipline);
        }

        public void Delete(int id)
        {
            _disciplineRepository.Delete(id);
        }

        public IEnumerable<Discipline> ListAll()
        {
            return _disciplineRepository.ListAll();
        }

        public Discipline Update(int id, Discipline discipline)
        {
            return _disciplineRepository.Update(id, discipline);
        }
    }
}
