using SrbComercialDomain.Entities;

namespace SrbComercialApplication.Common;

public interface IClientRepository : IRepository<Client>
{   
    void Update(Client entity);
}