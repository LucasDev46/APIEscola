using AutoMapper;
using School.Business.DTO.Aluno;
using School.Business.DTO.Disciplina;
using School.Business.DTO.Professor;
using School.Business.Models;

namespace School.Business.Mapper;

public class AutoMapperConfig : Profile
{

    public AutoMapperConfig()
    {
        CreateMap<Professor, CreateProfessorDTO>().ReverseMap();
        CreateMap<Professor, DadosProfessorDTO>();
        CreateMap<Professor, InativarProfessorDTO>().ReverseMap();
        CreateMap<Professor, UpdateProfessorDTO>().ReverseMap();
        CreateMap<DadosProfessorDTO, UpdateProfessorDTO>().ReverseMap();

        //disciplina
        CreateMap<Disciplina, DadosDisciplinaDTO>();
        CreateMap<Disciplina, CreateDisciplinaDTO>().ReverseMap();
        CreateMap<Disciplina, UpdateDisciplinaDTO>().ReverseMap();

        //Aluno
        CreateMap<Aluno, DadosAlunoDTO>().ReverseMap();
        CreateMap<Aluno, CriarAlunoDTO>().ReverseMap();
        CreateMap<Aluno, AtualizarAlunoDTO>().ReverseMap();
        CreateMap<Aluno, AlunoNotaDTO>();



    }
}
