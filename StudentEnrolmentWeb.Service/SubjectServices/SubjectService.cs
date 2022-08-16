using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.Data;
using StudentEnrolmentWebApp.Infrastructure.SubjectRep;

namespace StudentEnrolmentWebApp.Services.SubjectServices
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _subjectRepository.GetAll();
        }

        public async Task<Subject> GetById(int id)
        {
            return await _subjectRepository.GetById(id);
        }

        public async Task Add(Subject newSubject)
        {
            await _subjectRepository.Add(newSubject);
        }

        public async Task Update(int id, Subject newSubject)
        {
            await _subjectRepository.Update(id, newSubject);
        }

        public async Task Remove(int id)
        {
            await _subjectRepository.Remove(id);
        }
    }
}
