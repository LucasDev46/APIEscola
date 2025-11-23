
using Microsoft.EntityFrameworkCore;
using School.Business.Interface.Repository;
using School.Business.Models;
using School.Data.Context;

namespace School.Data.Repository
{
    public class MatriculaDisciplinaRepository : Repository<MatriculaDisciplina>, IMatriculaDisciplinaRepository
    {
        public MatriculaDisciplinaRepository(SchoolDbContext context) : base(context)
        {
        }
        public async Task<MatriculaDisciplina> GetMatriculaCompleta(long id)
        {
            return await _dbSet
                .Include(m => m.Notas)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<MatriculaDisciplina> GetMatriculaWithDetails(long id)
        {
            return await _dbSet.Include(md => md.Aluno)
                               .Include(md => md.Disciplina)
                               .Include(md => md.Notas)
                               .FirstOrDefaultAsync(md => md.Id == id);

        }
    }
}
