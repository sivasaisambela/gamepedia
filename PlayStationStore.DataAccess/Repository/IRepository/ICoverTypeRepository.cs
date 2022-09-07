using PlayStationStore.DataAccess.Repository.IRepository;
using PlayStationStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayStationStore.DataAccess.Repository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType obj);
       
    }
}
