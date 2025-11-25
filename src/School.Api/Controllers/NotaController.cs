using Microsoft.AspNetCore.Mvc;
using School.Business.DTO.Nota;
using School.Business.Interface.Services;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : MainController
    {
        private readonly INotaService _notaService;
        public NotaController(INotificador notificador, INotaService notaService) : base(notificador)
        {
            _notaService = notaService;
        }

        [HttpGet("todas-as-notas")]
        public async Task<ActionResult> ObterTodasNotas()
        {
            var notas = await _notaService.ObterTodos();
            return CustomResponse(notas);
        }
        [HttpGet("nota/{id:long}")]
        public async Task<ActionResult> ObterNotaById(long id)
        {
            var nota = await _notaService.ObterById(id);
            return CustomResponse(nota);
        }
        [HttpPost("criar-nota")]
        public async Task<ActionResult> CriarNota(CriarNotaDTO notaDto)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);
            var nota = await _notaService.Criar(notaDto);
            return CustomResponse(nota, 201);
        }
        [HttpPut("atualizar-nota/{id:long}")]
        public async Task<ActionResult> AtualizarNota(AtualizarNotaDTO notaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var nota = await _notaService.Atualizar(notaDto);
            return CustomResponse(nota);
        }
    }
}
