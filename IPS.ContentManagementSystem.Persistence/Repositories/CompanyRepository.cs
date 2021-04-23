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
    public class CompanyRepository : BaseRepsitory<Company>, ICompanyRepository
    {
        public CompanyRepository(IPSContentManagementDbContext iPSContentManagementDbContext) : base(iPSContentManagementDbContext)
        {
        }

        public async Task<List<Company>> GetCompaniesIsEnable(bool IsEnable)
        {
            var allCompanies = await _iPSContentManagementDbContext.Companies.Where(x => x.IsEnable == IsEnable).ToListAsync();

            return allCompanies;
        }
    }
}
