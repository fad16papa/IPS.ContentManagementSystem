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
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(IPSContentManagementDbContext iPSContentManagementDbContext) : base(iPSContentManagementDbContext)
        {
        }

        public async Task<List<Position>> GetPositionsIsEnable(bool IsEnable)
        {
            var allPositions = await _iPSContentManagementDbContext.Positions.Where(x => x.IsEnable == IsEnable).ToListAsync();

            return allPositions;
        }
    }
}
