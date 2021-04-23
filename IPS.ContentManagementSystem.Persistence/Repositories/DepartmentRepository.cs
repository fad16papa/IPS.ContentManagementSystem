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
    public class DepartmentRepository : BaseRepsitory<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IPSContentManagementDbContext iPSContentManagementDbContext) : base(iPSContentManagementDbContext)
        {
        }

        public async Task<List<Department>> GetDepartmentsIsEnable(bool IsEnable)
        {
            var allDepartments = await _iPSContentManagementDbContext.Departments.Where(x => x.IsEnable == IsEnable).ToListAsync();

            return allDepartments;
        }
    }
}
