using System;
using System.Collections.Generic;

namespace School.Business.Models
{
    public class Aluno : Pessoa
    {
        public string Matricula { get; set; }
        public ICollection<MatriculaDisciplina> DisciplinasMatriculadas { get; set; }
    }
}
