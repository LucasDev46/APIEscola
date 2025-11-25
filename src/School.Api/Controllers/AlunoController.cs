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
        public async Task<ActionResult<IEnumerable<DadosAlunoDTO>>> ObterTodosAlunos()
        {
            var alunos = await _alunoService.ObterTodos();
            return CustomResponse(alunos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<DadosAlunoDTO>> ObterAlunoById(long id)
        {
            var aluno = await _alunoService.ObterById(id);
            if (aluno is null) return CustomResponse();
            return CustomResponse(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<DadosAlunoDTO>> CriarAluno(CriarAlunoDTO alunoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var aluno = await _alunoService.Criar(alunoDto);
            if (aluno is null) return CustomResponse();
            return CustomResponse(aluno, 201);
        }

        [HttpPut("Atualizar-Aluno/{id:long}")]
        public async Task<ActionResult<DadosAlunoDTO>> AtualizarAluno(AtualizarAlunoDTO alunoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var aluno = await _alunoService.Atualizar(alunoDto);
            if (aluno is null) return CustomResponse();
            return CustomResponse(aluno);
        }

        [HttpPatch("inativar/{id:long}")]
        public async Task<ActionResult<DadosAlunoDTO>> InativarAluno(long id)
        {
            var aluno = await _alunoService.Inativar(id);
            if (aluno is false) return CustomResponse();
            return NoContent();
        }
    }
}
