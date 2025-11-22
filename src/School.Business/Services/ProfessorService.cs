
using AutoMapper;
using School.Business.DTO.Professor;
using School.Business.DTO.ValidationsDto;
using School.Business.Interface.Repository;
using School.Business.Interface.Services;
using School.Business.Models;

namespace School.Business.Services
{
    public class ProfessorService : BaseService, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public ProfessorService(IProfessorRepository professorRepository,
                                INotificador notificador,
                                IMapper mapper,
                                IPessoaRepository pessoaRepository) : base(notificador)
        {
            _professorRepository = professorRepository;
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IEnumerable<DadosProfessorDTO>> GetAllProf()
        {
            var prof = await _professorRepository.SelectAll();
            var ativo = prof.Where(p => p.Ativo);

            if (!ativo.Any())
            {
                Notificar("Nenhum professor ativo encontrado.");
                return null;
            }
            var result = _mapper.Map<IEnumerable<DadosProfessorDTO>>(ativo);
            return result;
        }

        public async Task<DadosProfessorDTO> GetProfById(long id)
        {

            var prof = await _professorRepository.SelectByQuery(p => p.Id == id);
            if (prof is null)
            {
                Notificar("Não existe um usuário com esse Id!");
                return null;
            }
            var result = _mapper.Map<DadosProfessorDTO>(prof);
            return result;
        }

        public async Task<DadosProfessorDTO> UpdateProf(UpdateProfessorDTO professor)
        {

            if (ExecutarValidacao(new UpdateProfessorValidator(), professor) == false) return null;

            var profResult = await _professorRepository.SelectByQuery(p => p.Id == professor.Id);
            if (profResult is null)
            {
                Notificar("Não foi encontrado um professor cadastrado com esse Id!");
                return null;
            }

            if (await _professorRepository.SelectByQuery(p => p.Email == professor.Email) != null)
            {
                Notificar("Já existe um professor cadastrado com este e-mail.");
                return null;
            }
            var prof = _mapper.Map<Professor>(professor);
            prof.RegistroFuncional = profResult.RegistroFuncional;

            _professorRepository.Update(prof);
            await _professorRepository.Commit();

            var result = _mapper.Map<DadosProfessorDTO>(prof);
            return result;

        }
        public async Task<DadosProfessorDTO> CreateProf(CreateProfessorDTO professor)
        {
            if(!ExecutarValidacao(new CreateProfessorValidator(), professor)) return null;
            if (await _pessoaRepository.GetPessoaByEmail(professor.Email) != null)
            {
                Notificar("Já existe um usuário cadastrado com este email!");
                return null;
            }
            var result = _mapper.Map<Professor>(professor);
            _professorRepository.Insert(result);
            await _professorRepository.Commit();
            var resultDto = _mapper.Map<DadosProfessorDTO>(result);
            return resultDto;
        }

        public async Task<bool> inativarProf(long id)
        {
            var prof = await _professorRepository.SelectByQuery(p => p.Id == id);
            if (prof is null)
            {
                Notificar("Usuário não encontrado!");
                return false;
            }
            if (!prof.Ativo)
            {
                Notificar("O professor já está inativo.");
                return false;
            }

            prof.Ativo = false;

            await _professorRepository.Commit();

            return true;
        }
    }
}
