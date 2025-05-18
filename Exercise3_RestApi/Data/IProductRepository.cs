using System.Collections.Generic;
using Exercise3_RestApi.Models;

namespace Exercise3_RestApi.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product Add(Product product);
        bool Update(int id, Product product);
        bool Delete(int id);
    }
}