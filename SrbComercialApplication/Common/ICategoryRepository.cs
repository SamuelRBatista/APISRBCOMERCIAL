using SrbComercialDomain.Entities;

namespace SrbComercialApplication.Common;
public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category entity);
}

