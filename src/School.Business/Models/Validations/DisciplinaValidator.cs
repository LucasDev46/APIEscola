using FluentValidation;


namespace School.Business.Models.Validations
{
    public class DisciplinaValidator : AbstractValidator<Disciplina>
    {

        public DisciplinaValidator()
        {
            RuleFor(p => p.Nome).NotEmpty()
                .WithMessage("O campo {propertyName} é obrigatório!")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.ProfessorId).NotEmpty()
                .WithMessage("É obrigatório informar o professor responsável pela disciplina!");
        }
    }
}
