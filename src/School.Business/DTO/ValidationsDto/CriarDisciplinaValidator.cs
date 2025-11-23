

using FluentValidation;
using School.Business.DTO.Disciplina;

namespace School.Business.DTO.ValidationsDto
{
    public class CriarDisciplinaValidator : AbstractValidator<CriarDisciplinaDTO>
    {

        public CriarDisciplinaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome da disciplina é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da disciplina não pode exceder 100 caracteres.");
            RuleFor(x => x.ProfessorId)
                .NotEmpty().WithMessage("O ID do professor é obrigatório.");
           
        }
    }
}
