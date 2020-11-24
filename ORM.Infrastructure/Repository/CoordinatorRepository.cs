using Dapper;
using ORM.Domain.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM.Infrastructure.Repository
{
    public class CoordinatorRepository : ICoordinatorRepository
    {
        private readonly string _connectionString;

        public CoordinatorRepository()
        {
            _connectionString = "Server=.\\SQLEXPRESS;Database=ORM;Trusted_Connection=True;MultipleActiveResultSets=true;";
        }

        public IEnumerable<Coordinator> ListAll()
        {
            var connection = new SqlConnection(_connectionString);

            var sensorData = connection.Query<Coordinator>("select * from coordinator");

            return sensorData;
        }

        public Coordinator Create(Coordinator coordinator)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into coordinator (name, cpf, birthdate, registration) values (@name, @cpf, @birthdate, @registration)";

            var result = connection.Execute(query, new { name = coordinator.Name, cpf = coordinator.CPF, birthdate = coordinator.BirthDate, registration = coordinator.Registration });

            connection.Execute(query, new { @id = result });

            return coordinator;
        }

        public Coordinator Update(int id, Coordinator coordinator)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "update coordinator set name = @name, cpf = @cpf, birthdate = @birthdate, registration = @registration where id = @id";

            var result = connection.Execute(query, new { name = coordinator.Name, cpf = coordinator.CPF, birthdate = coordinator.BirthDate, registration = coordinator.Registration, id });

            return coordinator;
        }

        public void Delete(int id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "delete from coordinator where id = @id";

            connection.Execute(query, new { id = id });
        }
    }
}
