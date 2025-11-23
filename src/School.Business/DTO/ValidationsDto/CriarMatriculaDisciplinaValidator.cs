
using FluentValidation;
using School.Business.DTO.MatriculaDisciplina;

namespace School.Business.DTO.ValidationsDto
{
    public class CriarMatriculaDisciplinaValidator : AbstractValidator<CriarMatriculaDisciplinaDTO>
    {
        public CriarMatriculaDisciplinaValidator()
        {
            RuleFor(m => m.AlunoId)
                .NotEmpty().WithMessage("Aluno é obrigatório e deve ser preenchido!");

            RuleFor(m => m.DisciplinaId)
                .NotEmpty().WithMessage("É obrigatório passar a disciplina em que o aluno estará cadastrado!");
        }
    }
}
