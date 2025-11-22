using FluentValidation;

namespace School.Business.Models.Validations
{
    public class MatriculaDisciplinaValidator : AbstractValidator<MatriculaDisciplina>
    {

        public MatriculaDisciplinaValidator()
        {
            RuleFor(m => m.AlunoId).NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!");
            RuleFor(m => m.DisciplinaId).NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!");
            RuleFor(m => m.NotaFinal).InclusiveBetween(0, 10)
                .When(m => m.NotaFinal.HasValue)
                .WithMessage("A nota final deve estare entre 0 e 10!");
        }
    }
}
