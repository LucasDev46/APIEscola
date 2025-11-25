

using Microsoft.EntityFrameworkCore;
using School.Business.Interface.Repository;
using School.Business.Models;
using School.Data.Context;

namespace School.Data.Repository
{
    public class NotaRepository : Repository<Nota>, INotaRepository
    {
        public NotaRepository(SchoolDbContext context) : base(context)
        {
        }
      public async Task<IEnumerable<Nota>> ObterNotaAluno()
        {
            return await _dbSet.Include(n => n.MatriculaDisciplina).ToListAsync();
        }
        

       public async Task<Nota> ObterNotaMatriculaPeloId(long id)
        {
            return await _dbSet.Where(n => n.Id == id)
                               .Include(n => n.MatriculaDisciplina)
                               .ThenInclude(md => md.Notas).FirstOrDefaultAsync();
        }

      
    }
}
