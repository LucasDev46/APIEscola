using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Models
{
    public class Disciplina : Entity
    {
        public string Nome { get; set; }

        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
