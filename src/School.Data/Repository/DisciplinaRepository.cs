using Microsoft.EntityFrameworkCore;
using School.Business.Interface.Repository;
using School.Business.Models;
using School.Data.Context;

namespace School.Data.Repository
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(SchoolDbContext context) : base(context)
        {
        }



        public async Task<Disciplina> GetDisciplinaWithProfessor(long id)
        {
            return await _dbSet.Include(p => p.Professor).AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
