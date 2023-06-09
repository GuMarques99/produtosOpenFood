using Microsoft.Extensions.Options;
using MongoDB.Driver;
using produtosOpenFood.Interfaces.Services;
using produtosOpenFood.Models;

namespace produtosOpenFood.Services
{

  public class ProductService : IProductService
  {
    private readonly IMongoCollection<Product> _productCollection;

    /// <summary>
    /// Serviço para salvar dados da classe Product
    /// </summary>
    /// <param name="database">Inicializado pela injeção de dependência</param>
    public ProductService(IMongoDatabase database)
    {
      _productCollection = database.GetCollection<Product>("produtos");
    }

    /// <summary>
    /// Recuperar todos os produtos não excluídos (status diferente de "thrash")
    /// </summary>
    /// <returns></returns>
    public async Task<List<Product>> Get()
    {
      return await _productCollection.Find(p => p.status != "thrash").ToListAsync();
    }

    /// <summary>
    /// Recuperar produto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Product> Get(string id)
    {
      var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
      return await _productCollection.Find(filter).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Inserir novo produto
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task<Product> Create(Product product)
    {
      await _productCollection.InsertOneAsync(product);
      return product;
    }

    /// <summary>
    /// Edição de um produto
    /// </summary>
    /// <param name="id"></param>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task<bool> Update(string id, Product product)
    {
      var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
      var result = await _productCollection.ReplaceOneAsync(filter, product);
      return result.ModifiedCount > 0;
    }

    /// <summary>
    /// Exclusão lógica de um produto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> Delete(string id)
    {
      var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
      var product = await _productCollection.Find(filter).FirstOrDefaultAsync();

      if (product == null) return false;

      product.status = "thrash";

      var result = await _productCollection.ReplaceOneAsync(filter, product);
      return result.ModifiedCount > 0;
    }
  }
}
