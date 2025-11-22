using AutoMapper;
using School.Business.DTO.Aluno;
using School.Business.DTO.ValidationsDto;
using School.Business.Interface.Repository;
using School.Business.Interface.Services;
using School.Business.Models;

namespace School.Business.Services
{
    public class AlunoService : BaseService, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public AlunoService(INotificador notificador, 
                            IAlunoRepository alunoRepository, 
                            IMapper mapper, 
                            IPessoaRepository pessoaRepository) : base(notificador)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }



        public async Task<DadosAlunoDTO> GetAlunoById(long id)
        {
            var aluno = await _alunoRepository.SelectByQuery(a => a.Id == id);
            if (aluno == null)
            {
                Notificar("Aluno não encontrado.");
                return null;
            }
            var alunoDto = _mapper.Map<DadosAlunoDTO>(aluno);
            return alunoDto;
        }

        public async Task<IEnumerable<DadosAlunoDTO>> GetTodosAlunos()
        {
            var alunos = await _alunoRepository.SelectAll();
            var alunosDto = _mapper.Map<IEnumerable<DadosAlunoDTO>>(alunos);
            return alunosDto;
        }

        public async Task<DadosAlunoDTO> CriarAluno(CriarAlunoDTO aluno)
        {
            if(ExecutarValidacao(new CriarAlunoValidator(), aluno) == false) return null;

            if(await _pessoaRepository.GetPessoaByEmail(aluno.Email) != null)
            {
                Notificar("Já existe um usuário cadastrado com este email!");
                return null;
            }
            var entity = _mapper.Map<Aluno>(aluno);
            _alunoRepository.Insert(entity);
            await _alunoRepository.Commit();
            var alunoDto = _mapper.Map<DadosAlunoDTO>(entity);
            return alunoDto;
        }

        public async Task<DadosAlunoDTO> AtualizarAluno(AtualizarAlunoDTO aluno)
        {
            if(ExecutarValidacao(new AtualizarAlunoValidator(), aluno) == false) return null;
            var result = await _alunoRepository.SelectByQuery(a => a.Id == aluno.Id);
            if (result == null)
            {
                Notificar("Aluno não encontrado.");
                return null;
            }
            _mapper.Map(aluno, result);
            _alunoRepository.Update(result);
            await _alunoRepository.Commit();
            var alunoDto = _mapper.Map<DadosAlunoDTO>(result);
            return alunoDto;
        }
  
        public async Task<bool> inativarAluno(long id)
        {
            var aluno = await _alunoRepository.SelectByQuery(a => a.Id == id);
            if (aluno == null)
            {
                Notificar("Aluno não encontrado.");
                return false;
            }
            if (!aluno.Ativo)
            {
                Notificar("Aluno já está inativo.");
                return false;
            }

            aluno.Ativo = false;
  
            await _alunoRepository.Commit();
            return true;
        }
    }
}
