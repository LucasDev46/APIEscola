using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Models.Validations
{
    public class ProfessorValidator : AbstractValidator<Professor>
    {

        public ProfessorValidator()
        {
            Include(new PessoaValidator());

            RuleFor(p => p.RegistroFuncional)
                .NotEmpty().WithMessage("O registro funcional é obrigatório.")
                .NotNull().WithMessage("O registro funcional não pode ser nulo.")
                .Length(5, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(p => p.Disciplina)
                .NotEmpty().WithMessage("O professor deve estar associado a pelo menos uma disciplina.");
        }
    }
}
