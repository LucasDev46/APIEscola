using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Models.Validations
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email informado é inválido.");
            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data no passado.");
            RuleFor(p => p.Tipo)
                .NotEmpty().WithMessage("O tipo é obrigatório.")
                .Must(t => t == "Aluno" || t == "Professor").WithMessage("O tipo deve ser 'Aluno' ou 'Professor'.");
        }
    }
}
