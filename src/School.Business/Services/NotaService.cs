
using AutoMapper;
using School.Business.DTO.Nota;
using School.Business.DTO.ValidationsDto;
using School.Business.Interface.Repository;
using School.Business.Interface.Services;
using School.Business.Models;

namespace School.Business.Services
{
    public class NotaService : BaseService, INotaService
    {
        private readonly IMatriculaDisciplinaRepository _matriculaDisciplinaRepository;
        private readonly INotaRepository _notaRepository;
        private readonly IMapper _mapper;

        public NotaService(INotificador notificador, 
                           IMatriculaDisciplinaRepository matriculaDisciplinaRepository, 
                           IMapper mapper, 
                           INotaRepository notaRepository) : base(notificador)
        {
            _matriculaDisciplinaRepository = matriculaDisciplinaRepository;
            _mapper = mapper;
            _notaRepository = notaRepository;
        }



        public async Task<IEnumerable<DadosNotaDTO>> ObterTodos()
        {
           var result = await _notaRepository.SelectAll();
           var dto = _mapper.Map<IEnumerable<DadosNotaDTO>>(result);
           return dto;
        }

        public async Task<DadosNotaDTO> ObterById(long id)
        {
            var result = await _notaRepository.SelectByQuery(n => n.Id == id);
            if(result is null)
            {
                Notificar("Nota não encontrada!");
                return null;
            }
            var dto = _mapper.Map<DadosNotaDTO>(result);
            return dto;
        }

        public async Task<DadosNotaDTO> Criar(CriarNotaDTO nota)
        {
            if(ExecutarValidacao(new CriarNotaValidator(), nota) == false) return null;
            var matricula = await _matriculaDisciplinaRepository.GetMatriculaCompleta(nota.MatriculaDisciplinaId);
            if (matricula == null)
            {
                Notificar("Matrícula da disciplina não encontrada.");
                return null;
            }
            if (matricula.Ativo == false)
            {
                Notificar("Não é possível acrescentar uma nota a uma matricula inativa!");
                return null;
            }
            var totalPeso = matricula.Notas.ToList();
            var somaPesos = totalPeso.Sum(n => n.Peso) + nota.Peso;
            if(somaPesos > 1)
            {
                Notificar("O peso total das notas não pode exceder 1.");
                return null;
            }

            var entity = _mapper.Map<Nota>(nota);
            _notaRepository.Insert(entity);
            await _notaRepository.Commit();
            if(somaPesos == 1)
            {
                var soma = totalPeso.Sum(n => n.Valor * n.Peso) + (nota.Valor * nota.Peso);
                matricula.NotaFinal = soma;
                _matriculaDisciplinaRepository.Update(matricula);
                await _matriculaDisciplinaRepository.Commit();
            }
            var dto = _mapper.Map<DadosNotaDTO>(entity);
            return dto;

        }
        public Task<DadosNotaDTO> Atualizar(CriarNotaDTO nota)
        {
            
            throw new NotImplementedException();
        }
    }
}
