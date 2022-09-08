using System;
using System.Collections.Generic;
using System.Text;

namespace PlayStationStore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        ICoverTypeRepository CoverType { get; }

        IProductRepository Product { get; }

        void Save();
    }
}
