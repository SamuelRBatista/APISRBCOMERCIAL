
using SrbComercialApplication.Common;
using SrbComercialDomain.Entities;
using SrbComercialInfrastructure.Data;

namespace SrbComercialInfrastructure.Repository;

public class ClientRepository : Repository<Client>, IClientRepository
{
    private readonly DataContext _db;

    public ClientRepository(DataContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Client entity)
    {
        _db.Update(entity);
    }
}