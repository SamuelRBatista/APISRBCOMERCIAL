using SrbComercialApplication.Common;
using SrbComercialDomain.Entities;
using SrbComercialInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrbComercialInfrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DataContext _db;

        public ProductRepository(DataContext db) : base(db)
        { 
            _db = db;                
        }

     
        public void Update(Product entity)
        {
            _db.Update(entity);
        }
    }
}
