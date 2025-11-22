using Microsoft.AspNetCore.Mvc;
using School.Business.DTO.Professor;
using School.Business.Interface.Services;


namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : MainController
    {
        private readonly IProfessorService _professorService;
   

        public ProfessorController(IProfessorService professorService, INotificador notificador) : base(notificador)
        {
            _professorService = professorService;
   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosProfessorDTO>>> GetAllProf()
        {

            var result = await _professorService.GetAllProf();
            if (result is null) return CustomResponse();
            return CustomResponse(result);

        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<DadosProfessorDTO>> GetProfById(long id)
        {
            var prof = await _professorService.GetProfById(id);
            if (prof is null) return CustomResponse();
            return CustomResponse(prof);

        }

        [HttpPost]
        public async Task<ActionResult> CreateProf(CreateProfessorDTO professor)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var result = await _professorService.CreateProf(professor);
            if (result is null) return CustomResponse();
            return CustomResponse(result, StatusCodes.Status201Created);

        }
        [HttpPut("Atualizar-Professor{id:long}")]
        public async Task<ActionResult> UpdateProf(UpdateProfessorDTO professor)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _professorService.UpdateProf(professor);
            if(result is null) return CustomResponse();

            return CustomResponse(professor, StatusCodes.Status200OK);
        }
        [HttpPatch("inativar/{id:long}")]
        public async Task<ActionResult> InactiveProf(long id)
        {
           var result = await _professorService.inativarProf(id);

            if (result is false)
                return CustomResponse();

            return NoContent();
        }
    }
}
