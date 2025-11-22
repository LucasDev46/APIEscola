

using AutoMapper;
using School.Business.DTO.Disciplina;
using School.Business.DTO.ValidationsDto;
using School.Business.Interface.Repository;
using School.Business.Interface.Services;
using School.Business.Models;

namespace School.Business.Services
{
    public class DisciplinaService : BaseService, IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;
        public DisciplinaService(INotificador notificador, IDisciplinaRepository disciplinaRepository, 
                                 IMapper mapper, 
                                 IProfessorRepository professorRepository) : base(notificador)
        {
            _disciplinaRepository = disciplinaRepository;
            _mapper = mapper;
            _professorRepository = professorRepository;
        }



        public async Task<IEnumerable<DadosDisciplinaDTO>> GetAllDisc()
        {
            var disc = await _disciplinaRepository.SelectAll();
            var discDto = _mapper.Map<IEnumerable<DadosDisciplinaDTO>>(disc);
            return discDto;
        }

       
        public async Task<DadosDisciplinaDTO> GetDiscById(long id)
        {
            var disc =  await _disciplinaRepository.GetDisciplinaWithProfessor(id);
            if (disc == null)
            {
                Notificar("Disciplina não encontrada.");
                return null;
            }
            var discDto = _mapper.Map<DadosDisciplinaDTO>(disc);
            return discDto;
        }

        public async Task<DadosDisciplinaDTO> CreateDisc(CreateDisciplinaDTO disciplina)
        {
            if(ExecutarValidacao(new CreateDisciplinaValidator(), disciplina) == false) return null;
            if(_disciplinaRepository.SelectByQuery(d => d.Nome == disciplina.Nome).Result != null)
            {
                Notificar("Já existe uma disciplina com esse nome.");
            }
            var prof = await _professorRepository.SelectByQuery(p => p.Id == disciplina.ProfessorId);
            if(prof == null)
            {
                Notificar("Não existe nenhum professor com esse Id!");
                return null;
            }
            var discEntity = _mapper.Map<Disciplina>(disciplina);
            
            _disciplinaRepository.Insert(discEntity);
            await _disciplinaRepository.Commit();
            var discDto = _mapper.Map<DadosDisciplinaDTO>(discEntity);
            return discDto;
        }

        public async Task<DadosDisciplinaDTO> UpdateDisc(UpdateDisciplinaDTO disciplina)
        {
            if(!ExecutarValidacao(new UpdateDiscipinaValidator(), disciplina)) return null;
            if(_disciplinaRepository.SelectByQuery(d => d.Nome == disciplina.Nome && d.Id != disciplina.Id).Result != null)
            {
                Notificar("Já existe uma disciplina com esse nome.");
                return null;
            }
            var entity = await _disciplinaRepository.SelectByQuery(d => d.Id == disciplina.Id);
            if(entity == null)
            {
                Notificar("Disciplina não encontrada.");
                return null;
            }
            _mapper.Map(disciplina, entity);
            _disciplinaRepository.Update(entity);
            await _disciplinaRepository.Commit();
            var discDto = _mapper.Map<DadosDisciplinaDTO>(entity);
            return discDto;

        }

        public async Task<bool> inativarDisc(long id)
        {
            var disc = await _disciplinaRepository.SelectByQuery(d => d.Id == id);
            if(disc is null) { 
                Notificar("Disciplina não encontrada.");
                return false;
            }
            if(!disc.Ativo)
            {
                Notificar("Disciplina já está inativa.");
                return false;
            }
            disc.Ativo = false;

            await _disciplinaRepository.Commit();
            return true;
        }


    }
}
