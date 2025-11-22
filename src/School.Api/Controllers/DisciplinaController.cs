using Microsoft.AspNetCore.Mvc;
using School.Business.DTO.Disciplina;
using School.Business.Interface.Services;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : MainController
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinaController(IDisciplinaService disciplinaService, INotificador notificador) : base(notificador)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosDisciplinaDTO>>> GetAllDisciplinas()
        {
            var disciplinas = await _disciplinaService.GetAllDisc();
            return CustomResponse(disciplinas);
        }


        [HttpGet("{id:long}")]

        public async Task<ActionResult<DadosDisciplinaDTO>> GetDisciplinaById(long id)
        {
            var disciplina = await _disciplinaService.GetDiscById(id);
            if (disciplina is null) return CustomResponse();
            return CustomResponse(disciplina);
        }

        [HttpPost]
        public async Task<ActionResult<DadosDisciplinaDTO>> CreateDisciplina(CreateDisciplinaDTO disciplinaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var disciplina = await _disciplinaService.CreateDisc(disciplinaDto);
            if (disciplina is null) return CustomResponse();
            return CustomResponse(disciplina, 201);
        }

        [HttpPut("Atualizar-Disciplina/{id:long}")]
        public async Task<ActionResult<DadosDisciplinaDTO>> UpdateDisciplina(UpdateDisciplinaDTO disciplinaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var disciplina = await _disciplinaService.UpdateDisc(disciplinaDto);
            if (disciplina is null) return CustomResponse();
            return CustomResponse(disciplina);
        }

        [HttpPatch("inativar/{id:long}")]
        public async Task<ActionResult<DadosDisciplinaDTO>> InativarDisciplina(long id)
        {
            var disciplina = await _disciplinaService.inativarDisc(id);
            if (disciplina is false) return CustomResponse();
            return NoContent();
        }
    }
}
