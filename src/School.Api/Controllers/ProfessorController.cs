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
        public async Task<ActionResult<IEnumerable<DadosProfessorDTO>>> ObterTodosProf()
        {

            var result = await _professorService.ObterTodos();
            if (result is null) return CustomResponse();
            return CustomResponse(result);

        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<DadosProfessorDTO>> ObterProfById(long id)
        {
            var prof = await _professorService.ObterById(id);
            if (prof is null) return CustomResponse();
            return CustomResponse(prof);

        }

        [HttpPost]
        public async Task<ActionResult> CriarProf(CriarProfessorDTO professor)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var result = await _professorService.Criar(professor);
            if (result is null) return CustomResponse();
            return CustomResponse(result, StatusCodes.Status201Created);

        }
        [HttpPut("Atualizar-Professor{id:long}")]
        public async Task<ActionResult> AtualizarProf(AtualizarProfessorDTO professor)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _professorService.Atualizar(professor);
            if(result is null) return CustomResponse();

            return CustomResponse(professor, StatusCodes.Status200OK);
        }
        [HttpPatch("inativar/{id:long}")]
        public async Task<ActionResult> InativarProf(long id)
        {
           var result = await _professorService.Inativar(id);

            if (result is false)
                return CustomResponse();

            return NoContent();
        }
    }
}
