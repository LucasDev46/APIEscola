

using FluentValidation;
using School.Business.DTO.Nota;

namespace School.Business.DTO.ValidationsDto
{
    public class AtualizarNotaValidator : AbstractValidator<AtualizarNotaDTO>
    {

        public AtualizarNotaValidator()
        {

            RuleFor(n => n.Valor)
                .NotEmpty().WithMessage("O valor da nota é obrigatório.")
                .InclusiveBetween(0, 10).WithMessage("O valor da nota deve estar entre 0 e 10.");
       
            RuleFor(n => n.Descricao)
                .NotEmpty().WithMessage("A descrição da nota é obrigatória.")
                .MaximumLength(100).WithMessage("A descrição da nota não pode exceder 100 caracteres.");
        }
    }
}
