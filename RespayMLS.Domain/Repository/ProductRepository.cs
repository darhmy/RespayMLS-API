using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespayMLS.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public ProductRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public Product AddProduct(Product product)
        {
            _respayMLSDbContext.Products.Add(product);

            _respayMLSDbContext.SaveChanges();

            return product;
        }

        public void Delete(int Id)
        {
            var getProduct = _respayMLSDbContext.Products.Find(Id);

            _respayMLSDbContext.Products.Remove(getProduct);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<Product> GetAllProducts()
        {
            return _respayMLSDbContext.Products.ToList();

        }

        public async Task<ICollection<Product>> GetAllProducts(string frequency, string currency, string planType, string sector, 
                                                                string productCategory)
        {
            var getAllProducts = await _respayMLSDbContext.Products.Include(frequency).Include(currency)
                                                            .Include(planType).Include(sector).Include(productCategory).ToListAsync();
            return getAllProducts;

        }

        public Product GetProduct(int Id)
        {
            return _respayMLSDbContext.Products.Find(Id);
        }

        public Product GetProduct(int Id, string frequency, string currency, string planType, string sector, string productCategory)
        {
            var getProduct = _respayMLSDbContext.Products.Include(frequency).Include(currency).Include(planType).Include(sector)
                                                       .Include(productCategory).Where(x => x.ProductId == Id).FirstOrDefault();

            return getProduct;
        }

        public Product UpdateProduct(Product product)
        {
            _respayMLSDbContext.Entry(product).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return product;
        }
    }
}
