using FluentValidation;
namespace School.Business.Models.Validations
{
    internal class NotaValidator : AbstractValidator<Nota>
    {

        public NotaValidator()
        {

            RuleFor(n => n.Valor)
                 .InclusiveBetween(0, 10)
                 .WithMessage("A nota deve estar entre 0 e 10.");

            RuleFor(n => n.Peso)
                .GreaterThan(0).WithMessage("O peso deve ser maior que zero.")
                .LessThanOrEqualTo(1).WithMessage("O peso não pode ser maior que 1.");

            RuleFor(n => n.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MinimumLength(3).WithMessage("A descrição deve ter ao menos {MinLength} caracteres.")
                .MaximumLength(100).WithMessage("A descrição deve ter no máximo {MaxLength} caracteres.");

            RuleFor(n => n.MatriculaDisciplinaId)
                .NotEmpty()
                .WithMessage("A matrícula da disciplina é obrigatória.");
        }
    }
}
