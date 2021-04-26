using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Persistence.Repositories
{
    public class AssessmentQustionsRepository : BaseRepository<AssessmentQuestions>, IAssessmentQuestionRepository
    {
        public AssessmentQustionsRepository(IPSContentManagementDbContext iPSContentManagementDbContext) : base(iPSContentManagementDbContext)
        {
        }

        public async Task<List<AssessmentQuestions>> GetAssessmentQuestionsIsEnable(bool IsEnable)
        {
            var allAssessmentQuestions = await _iPSContentManagementDbContext.AssessmentQuestions.Where(x => x.IsEnable == IsEnable).ToListAsync();

            return allAssessmentQuestions;
        }
    }
}
