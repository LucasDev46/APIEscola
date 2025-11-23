

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
      
    }
}
