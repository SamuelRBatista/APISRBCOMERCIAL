using SrbComercialApplication.Common;
using SrbComercialDomain.Entities;
using SrbComercialInfrastructure.Data;

namespace SrbComercialInfrastructure.Repository;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    private readonly DataContext _db;

    public SupplierRepository(DataContext db) :base(db)
    {
          _db = db;
    }

    public void Update(Supplier entity)
    {
         _db.Update(entity);
    }
}