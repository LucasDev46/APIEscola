

using FluentValidation;
using School.Business.DTO.Professor;

namespace School.Business.DTO.ValidationsDto
{
    public class AtualizarProfessorValidator : AbstractValidator<AtualizarProfessorDTO>
    {

        public AtualizarProfessorValidator()
        {
            Include(new PessoaDTOValidator());
        }
    }
}
