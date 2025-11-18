using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Models
{
    public class Professor : Pessoa
    {
        public string RegistroFuncional { get; set; }
        public ICollection<Disciplina> Disciplina { get; set; }
    }
}
