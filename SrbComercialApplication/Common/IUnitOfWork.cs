
namespace SrbComercialApplication.Common;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Product {  get; }

    ICategoryRepository Category { get; }

    ICityRepository City {get;}

    IStateRepository State { get; }

    ISupplierRepository Supplier {get;}

    IClientRepository Client {get;}

    void Save();
}
