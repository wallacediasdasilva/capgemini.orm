using ORM.Application.App.Interface;
using ORM.Domain.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Application.App
{
    public class CoordinatorApplication : ICoordinatorApplication
    {
        private readonly ICoordinatorRepository _coordinatorRepository;

        public CoordinatorApplication(ICoordinatorRepository coordinatorRepository)
        {
            _coordinatorRepository = coordinatorRepository;
        }

        public Coordinator Create(Coordinator coordinator)
        {
            return _coordinatorRepository.Create(coordinator);
        }

        public void Delete(int id)
        {
            _coordinatorRepository.Delete(id);
        }

        public IEnumerable<Coordinator> ListAll()
        {
            return _coordinatorRepository.ListAll();
        }

        public Coordinator Update(int id, Coordinator coordinator)
        {
            return _coordinatorRepository.Update(id, coordinator);
        }
    }
}
