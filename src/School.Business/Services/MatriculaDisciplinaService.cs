using AutoMapper;
using School.Business.DTO.Aluno;
using School.Business.DTO.MatriculaDisciplina;
using School.Business.DTO.ValidationsDto;
using School.Business.Interface.Repository;
using School.Business.Interface.Services;
using School.Business.Models;

namespace School.Business.Services
{
    public class MatriculaDisciplinaService : BaseService, IMatriculaDisciplinaService
    {
        private readonly IMatriculaDisciplinaRepository _matriculaDisciplinaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IMapper _mapper;
        public MatriculaDisciplinaService(INotificador notificador,
                                          IMatriculaDisciplinaRepository matriculaDisciplinaRepository, IMapper mapper,
                                          IAlunoRepository alunoRepository, 
                                          IDisciplinaRepository disciplinaRepository) : base(notificador)
        {
            _matriculaDisciplinaRepository = matriculaDisciplinaRepository;
            _mapper = mapper;
            _alunoRepository = alunoRepository;
            _disciplinaRepository = disciplinaRepository;
        }



        public async Task<DadosMatriculaDisciplinaDTO> ObterById(long id)
        {
            var matricula = await _matriculaDisciplinaRepository.GetMatriculaWithDetails(id);
            if(matricula is null)
            {
                Notificar("Matricula não encontrada!");
                return null;
            }
            var matriculaDto = _mapper.Map<DadosMatriculaDisciplinaDTO>(matricula);
            return matriculaDto;
        }

        public async Task<IEnumerable<DadosMatriculaDisciplinaDTO>> ObterTodos()
        {
           
            var matriculas = await _matriculaDisciplinaRepository.SelectAll();
            var dadosMatriculas = _mapper.Map<IEnumerable<DadosMatriculaDisciplinaDTO>>(matriculas);
            return dadosMatriculas;
        }


        public async Task<DadosMatriculaDisciplinaDTO> Criar(CriarMatriculaDisciplinaDTO matDisc)
        {
            if (!ExecutarValidacao(new CriarMatriculaDisciplinaValidator(), matDisc)) return null;

            if (await _alunoRepository.SelectByQuery(a => a.Id == matDisc.AlunoId) == null)
            {
                Notificar("Aluno não encontrado.");
                return null;
            }
            if (await _disciplinaRepository.SelectByQuery(d => d.Id == matDisc.DisciplinaId) == null)
            {
                Notificar("Disciplina não encontrada.");
                return null;
            }
            var matricula = _mapper.Map<MatriculaDisciplina>(matDisc);
            _matriculaDisciplinaRepository.Insert(matricula);
            await _matriculaDisciplinaRepository.Commit();
            var dadosMatricula = _mapper.Map<DadosMatriculaDisciplinaDTO>(matricula);
            return dadosMatricula;
        }
        public Task<DadosMatriculaDisciplinaDTO> Atualizar(AtualizarAlunoDTO matDisc)
        {
            //ainda será implementado
            throw new NotImplementedException();
        }

        public async Task<bool> Inativar(long id)
        {
            var matricula = await _matriculaDisciplinaRepository.SelectByQuery(m => m.Id == id);
            if (matricula == null)
            {
                Notificar("Matrícula não encontrada.");
                return false;
            }
            if(matricula.Ativo == false)
            {
                Notificar("Matrícula já está inativa.");
                return false;
            }
            matricula.Ativo = false;
            _matriculaDisciplinaRepository.Update(matricula);
            await _matriculaDisciplinaRepository.Commit();
            return true;

        }
    }
}
