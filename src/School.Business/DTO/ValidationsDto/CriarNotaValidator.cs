
using FluentValidation;
using School.Business.DTO.Nota;

namespace School.Business.DTO.ValidationsDto
{
    public class CriarNotaValidator : AbstractValidator<CriarNotaDTO>
    {

        public CriarNotaValidator()
        {
            RuleFor(n => n.Valor)
                .NotEmpty().WithMessage("O valor da nota é obrigatório.")
                .InclusiveBetween(0, 10).WithMessage("O valor da nota deve estar entre 0 e 10.");
            RuleFor(n => n.Peso)
                .NotEmpty().WithMessage("O peso da nota é obrigatório.")
                .InclusiveBetween(0, 1).WithMessage("O peso da nota deve estar entre 0 e 1.");
            RuleFor(n => n.Descricao)
                .NotEmpty().WithMessage("A descrição da nota é obrigatória.")
                .MaximumLength(100).WithMessage("A descrição da nota não pode exceder 100 caracteres.");
            RuleFor(n => n.MatriculaDisciplinaId)
                .NotEmpty().WithMessage("O ID da matrícula é obrigatório.")
                .GreaterThan(0).WithMessage("O ID da matrícula da disciplina deve ser maior que zero.");

        }

    }
}
