
using FluentValidation;
using School.Business.DTO.Aluno;

namespace School.Business.DTO.ValidationsDto
{
    public class AtualizarAlunoValidator : AbstractValidator<AtualizarAlunoDTO>
    {

        public AtualizarAlunoValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O nome do aluno é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(a => a.DataNascimento).GreaterThan(DateTime.MinValue)
                .WithMessage("A data de nascimento é obrigatória e deve ser uma data válida.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data no passado.");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("O email do aluno é obrigatório.")
                .EmailAddress().WithMessage("O email informado é inválido.");
        }
    }
}
