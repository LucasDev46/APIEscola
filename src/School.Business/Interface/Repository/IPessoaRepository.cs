

using School.Business.Models;

namespace School.Business.Interface.Repository
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Pessoa> ObterPessoaByEmail(string email);
    }
}
