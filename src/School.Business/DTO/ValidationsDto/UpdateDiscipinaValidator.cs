

using FluentValidation;
using School.Business.DTO.Disciplina;

namespace School.Business.DTO.ValidationsDto
{
    public class UpdateDiscipinaValidator : AbstractValidator<UpdateDisciplinaDTO>
    {

        public UpdateDiscipinaValidator()
        {
            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage("O nome da disciplina é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("O Id é obrigatório para fazer a alteração!");
            RuleFor(d => d.ProfessorId)
                .NotEmpty().WithMessage("O Id do professor é obrigatório.");
        }
    }
}
