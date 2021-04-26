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
    public class AssessmentTypeRepository : BaseRepository<AssessmentType>, IAssessmentTypeRepository
    {
        public AssessmentTypeRepository(IPSContentManagementDbContext iPSContentManagementDbContext) : base(iPSContentManagementDbContext)
        {
        }

        public async Task<List<AssessmentType>> GetAssessmentTypesIsEnable(bool IsEnable)
        {
            var allAssessmentTypes = await _iPSContentManagementDbContext.AssessmentTypes.Where(x => x.IsEnable == IsEnable).ToListAsync();

            return allAssessmentTypes;
        }
    }
}
