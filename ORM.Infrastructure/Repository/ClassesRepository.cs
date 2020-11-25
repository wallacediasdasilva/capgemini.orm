using Dapper;
using Microsoft.Extensions.Configuration;
using ORM.Domain.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM.Infrastructure.Repository
{
    public class ClassesRepository: IClassesRepository
    {
        private readonly string _connectionString;

        public ClassesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ORM");
        }

        public IEnumerable<Classes> ListAll()
        {
            var connection = new SqlConnection(_connectionString);

            var sensorData = connection.Query<Classes>("select * from classes");

            return sensorData;
        }

        public Classes Create(Classes classes)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into classes (name, coordinatorId) values (@name, @coordinator)";

            var result = connection.Execute(query, new { name = classes.Name, coordinator = classes.CoordinatorId });

            return classes;
        }

        public Classes Update(int id, Classes student)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "update classes set name = @name, where id = @id";

            var result = connection.Execute(query, new { name = student.Name, id });

            return student;
        }

        public void Delete(int id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "delete from classes where id = @id";

            connection.Execute(query, new { id = id });
        }

        public void Patch(int id, Classes classes)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "update classes set name = @name where id = @id";

            connection.Execute(query, new { name = classes.Name });
        }

        public void Relashionship(Registration registration)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into classes_discipline (classesid, disciplineid) values (@classes, @discipline)";

            connection.Execute(query, new { classes = registration.ClassesId, discipline = registration.DisciplineId });
        }
    }
}
