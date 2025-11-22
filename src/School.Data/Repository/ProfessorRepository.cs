using School.Business.Interface.Repository;
using School.Business.Models;
using School.Data.Context;


namespace School.Data.Repository
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(SchoolDbContext context) : base(context)
        {
        }
        
    }
}
