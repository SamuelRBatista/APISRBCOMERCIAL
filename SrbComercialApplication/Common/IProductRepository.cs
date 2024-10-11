
using SrbComercialDomain.Entities;

namespace SrbComercialApplication.Common
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product entity);
    }
}
