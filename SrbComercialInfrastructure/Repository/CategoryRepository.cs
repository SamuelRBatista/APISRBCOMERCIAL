using SrbComercialApplication.Common;
using SrbComercialDomain.Entities;
using SrbComercialInfrastructure.Data;

namespace SrbComercialInfrastructure.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly DataContext _db;

    public CategoryRepository(DataContext db) : base(db)
    {
        _db = db;
    
    }

    public void Update(Category entity)
    {
        _db.Update(entity);
    }
}

