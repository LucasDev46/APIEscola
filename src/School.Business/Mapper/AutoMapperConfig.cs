using AutoMapper;
using School.Business.DTO.Aluno;
using School.Business.DTO.Disciplina;
using School.Business.DTO.MatriculaDisciplina;
using School.Business.DTO.Nota;
using School.Business.DTO.Professor;
using School.Business.Models;

namespace School.Business.Mapper;

public class AutoMapperConfig : Profile
{

    public AutoMapperConfig()
    {
        CreateMap<Professor, CriarProfessorDTO>().ReverseMap();
        CreateMap<Professor, DadosProfessorDTO>();
        CreateMap<Professor, InativarProfessorDTO>().ReverseMap();
        CreateMap<Professor, AtualizarProfessorDTO>().ReverseMap();
        CreateMap<DadosProfessorDTO, AtualizarProfessorDTO>().ReverseMap();

        //disciplina
        CreateMap<Disciplina, DadosDisciplinaDTO>();
        CreateMap<Disciplina, CriarDisciplinaDTO>().ReverseMap();
        CreateMap<Disciplina, AtualizarDisciplinaDTO>().ReverseMap();

        //Aluno
        CreateMap<Aluno, DadosAlunoDTO>().ForMember(dest => dest.Disciplinas,
                                           opt => opt.MapFrom(src =>
                                           src.DisciplinasMatriculadas));
        CreateMap<Aluno, CriarAlunoDTO>().ReverseMap();
        CreateMap<Aluno, AtualizarAlunoDTO>().ReverseMap();
        CreateMap<Aluno, AlunoNotaDTO>();

        //matriculaDisciplina
        CreateMap<MatriculaDisciplina, DadosMatriculaDisciplinaDTO>().ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                                                                     .ForMember(dest => dest.NomeDisciplina, opt => opt.MapFrom(src => src.Disciplina.Nome));
        CreateMap<MatriculaDisciplina, CriarMatriculaDisciplinaDTO>().ReverseMap();
        CreateMap<MatriculaDisciplina, AtualizarMatriculaDisciplinaDTO>().ReverseMap();

        //nota
        CreateMap<Nota, DadosNotaDTO>();
        CreateMap<Nota, CriarNotaDTO>().ReverseMap();




    }
}
