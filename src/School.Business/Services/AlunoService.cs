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



        public async Task<DadosAlunoDTO> ObterById(long id)
        {
            var aluno = await _alunoRepository.ObterAlunoDisciplinas(id);
            if (aluno == null)
            {
                Notificar("Aluno não encontrado.");
                return null;
            }
            var alunoDto = _mapper.Map<DadosAlunoDTO>(aluno);
            return alunoDto;
        }

        public async Task<IEnumerable<DadosAlunoDTO>> ObterTodos()
        {
            var alunos = await _alunoRepository.ObterTodosAlunoDisciplina();
            var alunosDto = _mapper.Map<IEnumerable<DadosAlunoDTO>>(alunos);
            return alunosDto;
        }

        public async Task<DadosAlunoDTO> Criar(CriarAlunoDTO aluno)
        {
            if(ExecutarValidacao(new CriarAlunoValidator(), aluno) == false) return null;

            if(await _pessoaRepository.ObterPessoaByEmail(aluno.Email) != null)
            {
                Notificar("Já existe um usuário cadastrado com este email!");
                return null;
            }
            var entity = _mapper.Map<Aluno>(aluno);
            var gerarMatricula = $"ALU{DateTime.Now.Year}{new Random().Next(1000, 9999)}";
            entity.Matricula = gerarMatricula;
            _alunoRepository.Insert(entity);
            await _alunoRepository.Commit();
            var alunoDto = _mapper.Map<DadosAlunoDTO>(entity);
            return alunoDto;
        }

        public async Task<DadosAlunoDTO> Atualizar(AtualizarAlunoDTO aluno)
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
  
        public async Task<bool> Inativar(long id)
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
            _alunoRepository.Update(aluno);
            await _alunoRepository.Commit();
            return true;
        }
    }
}
