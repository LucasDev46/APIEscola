

using FluentValidation;

namespace School.Business.DTO.ValidationsDto
{
    public class PessoaDTOValidator : AbstractValidator<PessoaDTO>
    {
        public PessoaDTOValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O Id é obrigatório para fazer a alteração!");
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(a => a.DataNascimento).GreaterThan(DateTime.MinValue)
                .WithMessage("A data de nascimento é obrigatória e deve ser uma data válida.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data no passado.");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email informado é inválido.");
        }
    }
}
