
using School.Business.Interface.Repository;
using School.Business.Interface.Services;
using School.Business.Models;
using School.Business.Models.Validations;

namespace School.Business.Services
{
    public class ProfessorService : BaseService, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository, INotificador notificador) : base(notificador)
        {
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<Professor>> GetAllProf()
        {
            var prof = await _professorRepository.SelectAll();
            return prof.Where(p => p.Ativo == true);
        }

        public Task<Professor> GetProfById(Guid id)
        {
            return _professorRepository.SelectByQuery(p => p.Id == id);
        }

        public async Task<Professor> UpdateProf(Guid id, Professor professor)
        {
            if (id != professor.Id) return null;

            var prof = _professorRepository.SelectByQuery(p => p.Id == id);

            if (prof is null) return null;

            _professorRepository.Update(professor);
            await _professorRepository.Commit();

            return professor;

        }
        public async Task<bool> CreateProf(Professor professor)
        {
            if(!ExecutarValidacao(new ProfessorValidator(), professor)) return false;
            if(await _professorRepository.SelectByQuery(p => p.Email == professor.Email) != null)
            {
                Notificar("Já existe um professor cadastrado com este e-mail. :(");
                return false;
            }

            _professorRepository.Insert(professor);
            await _professorRepository.Commit();  
            return true;
        }

        public async Task<bool> inativarProf(Guid id)
        {
            var prof = await _professorRepository.SelectByQuery(p => p.Id == id);
            if (prof is null) return false;

            prof.Ativo = false;
            _professorRepository.Update(prof);
            await _professorRepository.Commit();

            return true;
        }
    }
}
