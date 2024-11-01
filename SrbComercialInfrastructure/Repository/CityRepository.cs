using Microsoft.EntityFrameworkCore;
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

    public List<City> GetCitiesByStateId(int stateId)
    {
       
       return _db.Set<City>().Where(c => c.StateId == stateId).ToList();
       
    }

    public async Task<City?> GetCityByIdAsync(int cityId)
    {
        return await _db.Set<City>().FindAsync(cityId);
    }

    public void Update(City entity)
    {
        _db.Update(entity);
    }

}
