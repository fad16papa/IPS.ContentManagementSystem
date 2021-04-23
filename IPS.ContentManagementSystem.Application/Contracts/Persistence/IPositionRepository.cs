using IPS.ContentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Contracts.Persistence
{
    public interface IPositionRepository : IAsyncRepository<Position>
    {
        Task<List<Position>> GetPositionsIsEnable(bool IsEnable);
    }
}
