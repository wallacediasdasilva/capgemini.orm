using Dapper;
using ORM.Domain.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM.Infrastructure.Repository
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly string _connectionString;

        public DisciplineRepository()
        {
            _connectionString = "Server=.\\SQLEXPRESS;Database=ORM;Trusted_Connection=True;MultipleActiveResultSets=true;";
        }

        public IEnumerable<Discipline> ListAll()
        {
            var connection = new SqlConnection(_connectionString);

            var sensorData = connection.Query<Discipline>("select * from discipline");

            return sensorData;
        }

        public Discipline Create(Discipline discipline)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into discipline (name, birthdate, ra, cpf)values (@name, @birthdate, @ra, @cpf)";

            var result = connection.Execute(query, new { name = discipline.Name });

            return discipline;
        }

        public Discipline Update(int id, Discipline discipline)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "update discipline set name = @name, birthdate = @birthdate, ra = @ra, cpf = @cpf where id = @id";

            var result = connection.Execute(query, new { name = discipline.Name, id = discipline.Id });

            return discipline;
        }

        public void Delete(int id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "delete from discipline where id = @id";

            connection.Execute(query, new { id = id });
        }
    }
}
