
using SrbComercialDomain.Entities;

namespace SrbComercialApplication.Common;

public interface ICityRepository : IRepository<City>
{
     void Update(City entity);
}