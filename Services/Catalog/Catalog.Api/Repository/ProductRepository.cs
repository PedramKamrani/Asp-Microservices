using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products =await _context.Product.Find(P => true).ToListAsync();
            return products;
        }

        public async Task<Product> GetProduct(string id)
        {
            var product =await _context.Product.Find(c => c.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var categories =await _context.Product.Find(x => x.Name == name).ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var category =await _context.Product.Find(x => x.Category == categoryName).ToListAsync();
            return category;
        }

        public async Task CreateProduct(Product product)
        {
             await _context.Product.InsertOneAsync(product);
            
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result =await _context.Product.ReplaceOneAsync(x => x.Id == product.Id, product);
            return result.IsAcknowledged && result.ModifiedCount > 0;


        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> definition = Builders<Product>.Filter.Eq(c => c.Id, id);
            var res = await _context.Product.DeleteOneAsync(definition);
            return res.IsAcknowledged && res.DeletedCount > 0;

        }
    }
}