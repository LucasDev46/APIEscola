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
            var matricula = await _matriculaDisciplinaRepository.ObterMatriculaComDetalhes(id);
            if(matricula is null)
            {
                Notificar("Matricula não encontrada!");
                return null;
            }
            var matriculaDto = _mapper.Map<DadosMatriculaDisciplinaDTO>(matricula);
            return matriculaDto;
        }

        public async Task<IEnumerable<DadosMatriculaDTO>> ObterTodos()
        {
           
            var matriculas = await _matriculaDisciplinaRepository.ObterTodasMatriculasComDetalhes();
            var dadosMatriculas = _mapper.Map<IEnumerable<DadosMatriculaDTO>>(matriculas);
            return dadosMatriculas;
        }


        public async Task<DadosMatriculaDTO> Criar(CriarMatriculaDisciplinaDTO matDisc)
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
            var existeMatricula = await _matriculaDisciplinaRepository.SelectByQuery(a => a.AlunoId == matDisc.AlunoId && a.DisciplinaId == matDisc.DisciplinaId);
            
            if(existeMatricula != null)
            {
                Notificar("Aluno ja cadastrado na disciplina!");
                return null;
            }
            var matricula = _mapper.Map<MatriculaDisciplina>(matDisc);
            _matriculaDisciplinaRepository.Insert(matricula);
            await _matriculaDisciplinaRepository.Commit();
            var dadosMatricula = await _matriculaDisciplinaRepository.ObterMatriculaComDetalhes(matricula.Id);
            var dadosMatriculaDto = _mapper.Map<DadosMatriculaDTO>(dadosMatricula);
            return dadosMatriculaDto;
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
