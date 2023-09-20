using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Vivid.Data.Interfaces;
using Vivid.Models;
using Vivid.ViewModels;

namespace Vivid.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly DapperContext _dapperContext;

        public ActorRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<Actor>> GetAllActors()
        {
            var query = "SELECT * FROM Actors";
            using (var connection = _dapperContext.CreateConnection())
            {
                var actors = await connection.QueryAsync<Actor>(query);
                return actors.ToList();
            }
        }

        public async Task<Actor> GetActorById(int id)
        {
            var query = "SELECT * FROM Actors WHERE Id = @Id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var club = await connection.QuerySingleOrDefaultAsync<Actor>(query, new { id });
                return club;
            }
        }

        public async Task<Actor> CreateActor(CreateActorViewModel createActorVM)
        {
            // Proceed with actor creation
            var query = "INSERT INTO Actors (Name, Bio, City, CreatedDate) VALUES (@Name, @Bio, @City, @CreatedDate)" +
                        "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", createActorVM.Name, DbType.String);
            parameters.Add("Bio", createActorVM.Bio, DbType.String);
            parameters.Add("City", createActorVM.City, DbType.String);
            parameters.Add("CreatedDate", DateTime.Now, DbType.DateTime);

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdActor = new Actor
                {
                    Id = id,
                    Name = createActorVM.Name,
                    Bio = createActorVM.Bio,
                    City = createActorVM.City,
                };

                return createdActor;
            }
        }

        public async Task UpdateActor(int id, EditActorViewModel editActorVM)
        {
            var query = "UPDATE Actors SET Name = @Name, Bio = @Bio, City = @City, BirthDate = @BirthDate WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", editActorVM.Name, DbType.String);
            parameters.Add("Bio", editActorVM.Bio, DbType.String);
            parameters.Add("City", editActorVM.City, DbType.String);
            parameters.Add("BirthDate", editActorVM.BirthDate, DbType.String);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteActor(int id)
        {
            var query = "DELETE FROM Actors WHERE Id = @Id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<bool> IsNameExists(string name)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "SELECT COUNT(*) FROM Actors WHERE Name = @Name";
                var parameters = new DynamicParameters();
                parameters.Add("Name", name, DbType.String);

                var count = await connection.ExecuteScalarAsync<int>(query, parameters);

                return count > 0;
            }
        }
    }
}