using Microsoft.EntityFrameworkCore;
using School.Business.Interface.Repository;
using School.Business.Models;
using School.Data.Context;

namespace School.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(SchoolDbContext context) : base(context)
        {
        }

        public async Task<Pessoa> ObterPessoaByEmail(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
