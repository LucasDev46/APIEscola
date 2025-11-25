
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

        public async Task<Aluno> ObterAlunoDisciplinas(long id)
        {
            return await _dbSet.Include(a => a.DisciplinasMatriculadas)
                .ThenInclude(a => a.Disciplina)
                .Include(a => a.DisciplinasMatriculadas)
                .ThenInclude(a => a.Notas)
                .FirstOrDefaultAsync(a => a.Id == id);

        }
        public async Task<IEnumerable<Aluno>> ObterTodosAlunoDisciplina()
        {
            return await _dbSet.Include(a => a.DisciplinasMatriculadas)
                .ThenInclude(a => a.Disciplina)
                .ToListAsync();
        }
    }
}
