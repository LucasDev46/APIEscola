using AutoMapper;
using School.Api.DTO;
using School.Business.Models;

namespace School.Api.Config
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Professor, CreateProfessorDTO>().ReverseMap();
            CreateMap<Professor, DadosProfessorDTO>().ReverseMap();
            CreateMap<Professor, InativarProfessorDTO>().ReverseMap();
        }
    }
}
