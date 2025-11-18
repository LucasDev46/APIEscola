using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Models.Validations
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {

        public AlunoValidator()
        {
            Include(new PessoaValidator());
            RuleFor(a => a.Matricula)
                .NotEmpty().WithMessage("A matrícula é obrigatória.")
                .NotNull().WithMessage("A matrícula não pode ser nula.")
                .Length(5, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
