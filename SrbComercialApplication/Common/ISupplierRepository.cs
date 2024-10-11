

using SrbComercialDomain.Entities;

namespace SrbComercialApplication.Common;

public interface ISupplierRepository : IRepository<Supplier>
{
     void Update(Supplier entity);
}