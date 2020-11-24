using ORM.Application.App.Interface;
using ORM.Domain.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Application.App
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IStudentRepository _studentRepository;

        public StudentApplication(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Create(Student student)
        {
            return _studentRepository.CreateStudent(student);
        }

        public void Delete(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public IEnumerable<Student> ListAll()
        {
            return _studentRepository.ListAll();
        }

        public void Patch(int id, Student student)
        {
            _studentRepository.Patch(id, student);
        }

        public Student Update(int id, Student student)
        {
            return _studentRepository.UpdateStudent(id, student);
        }
    }
}
