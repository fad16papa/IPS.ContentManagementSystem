using IPS.ContentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Contracts.Persistence
{
    public interface IDepartmentRepository : IAsyncRepository<Department>
    {
        Task<List<Department>> GetDepartmentsIsEnable(bool IsEnable);
    }
}
