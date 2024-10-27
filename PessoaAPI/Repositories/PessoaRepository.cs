using Dapper;
using MySql.Data.MySqlClient;
using PessoaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PessoaAPI.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly string _connectionString;

        public PessoaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Pessoa>("SELECT * FROM Pessoa");
            }
        }

        public async Task<Pessoa> GetById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Pessoa>("SELECT * FROM Pessoa WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<int> Create(Pessoa pessoa)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Pessoa (Nome, DataNascimento, UF, Cidade) VALUES (@Nome, @DataNascimento, @UF, @Cidade)";
                return await connection.ExecuteAsync(sql, pessoa);
            }
        }

        public async Task<int> Update(Pessoa pessoa)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "UPDATE Pessoa SET Nome = @Nome, DataNascimento = @DataNascimento, UF = @UF, Cidade = @Cidade WHERE Id = @Id";
                return await connection.ExecuteAsync(sql, pessoa);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync("DELETE FROM Pessoa WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
