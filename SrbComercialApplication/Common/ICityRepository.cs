
using SrbComercialDomain.Entities;

namespace SrbComercialApplication.Common;

public interface ICityRepository : IRepository<City>
{
     void Update(City entity);
    List<City> GetCitiesByStateId(int stateId);
    Task<City?> GetCityByIdAsync(int cityId);

}