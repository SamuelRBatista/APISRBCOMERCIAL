using SrbComercialApplication.Common;
using SrbComercialDomain.Entities;
using SrbComercialInfrastructure.Data;

namespace SrbComercialInfrastructure.Repository;

public class CityRepository : Repository<City>, ICityRepository
{
    private readonly DataContext _db;
     public CityRepository(DataContext db) : base(db)
     {
        _db = db;
     }

       public void Update(City entity)
        {
            _db.Update(entity);
        }

}
