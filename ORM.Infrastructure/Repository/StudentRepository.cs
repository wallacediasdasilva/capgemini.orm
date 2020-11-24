using Dapper;
using Microsoft.Extensions.Configuration;
using ORM.Domain.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = "Server=.\\SQLEXPRESS;Database=ORM;Trusted_Connection=True;MultipleActiveResultSets=true;";
        }

        public IEnumerable<Student> ListAll()
        {
            var connection = new SqlConnection(_connectionString);

            var sensorData = connection.Query<Student>("select * from Student");

            return sensorData;
        }

        public int Insert(long step)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into student (step)values (@step)";

            var result = connection.Execute(query, new { step = step });

            return result;
        }

        public Student CreateStudent(Student student)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into student (name, birthdate, ra, cpf, classesid)values (@name, @birthdate, @ra, @cpf, @classes)";

            var result = connection.Execute(query, new { name = student.Name, birthdate = student.BirthDate, ra = student.RA, cpf = student.CPF, classes = student.ClassesId });

            return student;
        }

        public Student UpdateStudent(int id, Student student)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "update student set name = @name, birthdate = @birthdate, ra = @ra, cpf = @cpf, classesid = @classes where id = @id";

            var result = connection.Execute(query, new { name = student.Name, birthdate = student.BirthDate, ra = student.RA, cpf = student.CPF, classes = student.ClassesId, id });

            return student;
        }

        public void DeleteStudent(int id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "delete from student where id = @id";

            connection.Execute(query, new { id = id });
        }

        public void Patch(int id, Student student)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "update student set name = @name, birthdate = @birthdate, ra = @ra, cpf = @cpf, classesid = @classes where id = @id";

            connection.Execute(query, new { name = student.Name, birthdate = student.BirthDate, ra = student.RA, cpf = student.CPF, id, classes = student.ClassesId });
        }
    }
}