using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.DTO.MatriculaDisciplina;
using School.Business.Interface.Services;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaDisciplinaController : MainController
    {
        private readonly IMatriculaDisciplinaService _matriculaDisciplinaService;
        public MatriculaDisciplinaController(INotificador notificador, IMatriculaDisciplinaService matriculaDisciplinaService) : base(notificador)
        {
            _matriculaDisciplinaService = matriculaDisciplinaService;
        }

        [HttpGet("todas-matriculas")]
        public async Task<ActionResult> GetTodasMatriculas()
        {
            var matriculas = await _matriculaDisciplinaService.ObterTodos();
            return CustomResponse(matriculas);
        }

        [HttpGet("buscar-matricula/{id:long}")]
        public async Task<ActionResult> GetMatriculaById(long id)
        {
            var result = await _matriculaDisciplinaService.ObterById(id);
            return CustomResponse(result);
        }

        [HttpPost("criar-matricula")]
        public async Task<ActionResult> CriarMatricula(CriarMatriculaDisciplinaDTO matDisc)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState); 
            var matricula = await _matriculaDisciplinaService.Criar(matDisc);
            return CustomResponse(matricula);
        }

        [HttpPatch("inativar-matricula/{id:long}")]
        public async Task<ActionResult> InativarMatricula(long id)
        {
            var result = await _matriculaDisciplinaService.Inativar(id);
            return CustomResponse(result);
        }
    }
}
