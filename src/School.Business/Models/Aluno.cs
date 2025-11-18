using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Models
{
    public class Aluno : Pessoa
    {
        public string Matricula { get; set; }
        public ICollection<MatriculaDisciplina> DisciplinasMatriculadas { get; set; }
    }
}
