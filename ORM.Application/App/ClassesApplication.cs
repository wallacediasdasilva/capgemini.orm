using ORM.Application.App.Interface;
using ORM.Domain.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Application.App
{
    public class ClassesApplication : IClassesApplication
    {
        private readonly IClassesRepository _classesRepository;

        public ClassesApplication(IClassesRepository classesRepository)
        {
            _classesRepository = classesRepository;
        }

        public Classes CreateStudent(Classes student)
        {
            return _classesRepository.Create(student);
        }

        public void DeleteStudent(int id)
        {
            _classesRepository.Delete(id);
        }

        public IEnumerable<Classes> ListAll()
        {
            return _classesRepository.ListAll();
        }

        public void Patch(int id, Classes classes)
        {
            _classesRepository.Patch(id, classes);
        }

        public void Relashionship(Registration registration)
        {
            _classesRepository.Relashionship(registration);
        }

        public Classes UpdateStudent(int id, Classes student)
        {
            return _classesRepository.Update(id, student);
        }
    }
}
