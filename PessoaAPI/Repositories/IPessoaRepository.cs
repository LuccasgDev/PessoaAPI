using PessoaAPI.Models;

namespace PessoaAPI.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAll();
        Task<Pessoa> GetById(int id);
        Task<int> Create(Pessoa pessoa);
        Task<int> Update(Pessoa pessoa);
        Task<int> Delete(int id);
    }
}
