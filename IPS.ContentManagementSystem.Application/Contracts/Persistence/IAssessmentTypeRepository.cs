using IPS.ContentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Contracts.Persistence
{
    public interface IAssessmentTypeRepository : IAsyncRepository<AssessmentType>
    {
        Task<List<AssessmentType>> GetAssessmentTypesIsEnable(bool IsEnable);
    }
}
