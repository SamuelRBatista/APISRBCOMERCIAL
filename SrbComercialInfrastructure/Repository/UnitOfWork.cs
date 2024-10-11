using SrbComercialApplication.Common;
using SrbComercialInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrbComercialInfrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _db;

        public IProductRepository Product { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public ICityRepository City { get; private set; }

        public ISupplierRepository Supplier { get; private set; }

        public IClientRepository Client {get; private set;}

        public UnitOfWork(DataContext db)
        {
            _db = db;
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db); 
            City = new CityRepository(_db); 
            Supplier = new SupplierRepository(_db);
            Client = new ClientRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
