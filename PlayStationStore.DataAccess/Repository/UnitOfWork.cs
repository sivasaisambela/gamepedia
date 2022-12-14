using System;
using System.Collections.Generic;
using System.Text;
using PlayStationStore.DataAccess.Repository.IRepository;

namespace PlayStationStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;

            Category= new CategoryRepository(_db);

            CoverType = new CoverTypeRepository(_db);

            Product = new ProductRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
