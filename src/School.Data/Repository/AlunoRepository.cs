
using Microsoft.EntityFrameworkCore;
using School.Business.Interface.Repository;
using School.Business.Models;
using School.Data.Context;

namespace School.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(SchoolDbContext context) : base(context)
        {
        }

        public async Task<Aluno> GetAlunoWithDisciplinas(long id)
        {
            return await _dbSet.Include(a => a.DisciplinasMatriculadas).AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
