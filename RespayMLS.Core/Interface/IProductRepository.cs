using RespayMLS.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);

        Product GetProduct(int Id, string frequency, string currency, string planType, string sector, string productCategory);

        ICollection<Product> GetAllProducts();

        Task<ICollection<Product>> GetAllProducts(string frequency, string currency, string planType, string sector, string productCategory);

        Product AddProduct(Product product);

        Product UpdateProduct(Product product);

        void Delete(int Id);
    }
}
