using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IProductCategoryRepository
    {
        ProductCategory GetProductCategory(int Id);

        ICollection<ProductCategory> GetAllProductCategories();

        ProductCategory AddProductCategory(ProductCategory productCategory);

        ProductCategory UpdateProductCategory(ProductCategory productCategory);

        void Delete(int Id);
    }
}
