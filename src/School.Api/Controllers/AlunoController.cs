using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.DTO.Aluno;
using School.Business.Interface.Services;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : MainController
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(INotificador notificador, IAlunoService alunoService) : base(notificador)
        {
            _alunoService = alunoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosAlunoDTO>>> GetAllAlunos()
        {
            var alunos = await _alunoService.GetTodosAlunos();
            return CustomResponse(alunos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<DadosAlunoDTO>> GetAlunoById(long id)
        {
            var aluno = await _alunoService.GetAlunoById(id);
            if (aluno is null) return CustomResponse();
            return CustomResponse(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<DadosAlunoDTO>> CreateAluno(CriarAlunoDTO alunoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var aluno = await _alunoService.CriarAluno(alunoDto);
            if (aluno is null) return CustomResponse();
            return CustomResponse(aluno, 201);
        }

        [HttpPut("Atualizar-Aluno/{id:long}")]
        public async Task<ActionResult<DadosAlunoDTO>> UpdateAluno(AtualizarAlunoDTO alunoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var aluno = await _alunoService.AtualizarAluno(alunoDto);
            if (aluno is null) return CustomResponse();
            return CustomResponse(aluno);
        }

        [HttpPatch("inativar/{id:long}")]
        public async Task<ActionResult<DadosAlunoDTO>> InativarAluno(long id)
        {
            var aluno = await _alunoService.inativarAluno(id);
            if (aluno is false) return CustomResponse();
            return NoContent();
        }
    }
}
