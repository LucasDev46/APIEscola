
using FluentValidation;
using School.Business.DTO.Aluno;

namespace School.Business.DTO.ValidationsDto
{
    public class AtualizarAlunoValidator : AbstractValidator<AtualizarAlunoDTO>
    {

        public AtualizarAlunoValidator()
        {
            Include(new PessoaDTOValidator());
        }
    }
}
