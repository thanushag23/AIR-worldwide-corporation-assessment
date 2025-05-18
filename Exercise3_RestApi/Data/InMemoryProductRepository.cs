using System.Collections.Concurrent;
using Exercise3_RestApi.Models;

namespace Exercise3_RestApi.Data
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<int, Product> _store = new();
        private int _nextId = 1;

        public InMemoryProductRepository()
        {
            Add(new Product { Name = "Sample", Price = 9.99M });
        }

        public IEnumerable<Product> GetAll() => _store.Values;

        public Product? GetById(int id) =>
            _store.TryGetValue(id, out var p) ? p : null;

        public Product Add(Product product)
        {
            var id = _nextId++;
            product.Id = id;
            _store[id] = product;
            return product;
        }

        public bool Update(int id, Product product)
        {
            if (!_store.ContainsKey(id)) return false;
            product.Id = id;
            _store[id] = product;
            return true;
        }

        public bool Delete(int id) =>
            _store.TryRemove(id, out _);
    }
}