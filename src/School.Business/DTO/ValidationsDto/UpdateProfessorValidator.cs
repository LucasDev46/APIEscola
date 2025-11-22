

using FluentValidation;
using School.Business.DTO.Professor;

namespace School.Business.DTO.ValidationsDto
{
    public class UpdateProfessorValidator : AbstractValidator<UpdateProfessorDTO>
    {

        public UpdateProfessorValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O Id é obrigatório para fazer a alteração!");
            RuleFor(p => p.Nome)
               .NotEmpty().WithMessage("O nome é obrigatório.")
               .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data no passado.");


            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email informado é inválido.");
        }
    }
}
