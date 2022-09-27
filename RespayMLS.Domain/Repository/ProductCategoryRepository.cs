using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Domain.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public ProductCategoryRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }

        public ProductCategory AddProductCategory(ProductCategory productCategory)
        {
            _respayMLSDbContext.ProductCategories.Add(productCategory);

            _respayMLSDbContext.SaveChanges();

            return productCategory;
        }

        public void Delete(int Id)
        {
            var getProductCategory = _respayMLSDbContext.ProductCategories.Find(Id);

            _respayMLSDbContext.ProductCategories.Remove(getProductCategory);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<ProductCategory> GetAllProductCategories()
        {
            return _respayMLSDbContext.ProductCategories.ToList();
        }

        public ProductCategory GetProductCategory(int Id)
        {
            var getProductCategory = _respayMLSDbContext.ProductCategories.Find(Id);

            return getProductCategory;
        }

        public ProductCategory UpdateProductCategory(ProductCategory productCategory)
        {
            _respayMLSDbContext.Entry(productCategory).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return productCategory;
        }
    }
}
