using produtosOpenFood.Models;

namespace produtosOpenFood.Interfaces.Services
{
  public interface IProductService
  {
    Task<Product> Create(Product product);
    Task<bool> Delete(string id);
    Task<List<Product>> Get();
    Task<Product> Get(string id);
    Task<bool> Update(string id, Product product);
  }
}
