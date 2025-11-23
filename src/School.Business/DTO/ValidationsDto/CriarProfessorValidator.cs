
using FluentValidation;
using School.Business.DTO.Professor;

namespace School.Business.DTO.ValidationsDto
{
    public class CriarProfessorValidator : AbstractValidator<CriarProfessorDTO>
    {
        public CriarProfessorValidator()
        {

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data no passado.");


            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email informado é inválido.");

            RuleFor(p => p.RegistroFuncional)
                .NotEmpty().WithMessage("O registro funcional é obrigatório.")
                .NotNull().WithMessage("O registro funcional não pode ser nulo.")
                .Length(5, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
