using PlayStationStore.DataAccess.Repository.IRepository;
using PlayStationStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayStationStore.DataAccess.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
       
    }
}
