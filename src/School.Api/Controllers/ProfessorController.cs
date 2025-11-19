using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Api.DTO;
using School.Business.Interface.Services;
using School.Business.Models;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : MainController
    {
        private readonly IProfessorService _professorService;
        private readonly IMapper _mapper;

        public ProfessorController(IProfessorService professorService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _professorService = professorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosProfessorDTO>>> GetAllProf()
        {

            var profs = await _professorService.GetAllProf();
            var profsDto = _mapper.Map<IEnumerable<DadosProfessorDTO>>(profs);
            return Ok(_mapper.Map<IEnumerable<DadosProfessorDTO>>(await _professorService.GetAllProf()));

        }

        [HttpPost]
        public async Task<ActionResult> CreateProf(CreateProfessorDTO professor)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _professorService.CreateProf(_mapper.Map<Professor>(professor));

            if(!result) return CustomResponse(professor);

            var dto = _mapper.Map<DadosProfessorDTO>(professor);
            return CustomResponse(dto, StatusCodes.Status201Created);
           
        }
        [HttpPatch("inativar/{id:guid}")]
        public async Task<ActionResult> UpdateProf(Guid id)
        {
           var result = await _professorService.inativarProf(id);

            if(result is false)
                return NotFound();

            return NoContent();
        }
    }
}
