using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespayMLS.Domain.Repository
{
    public class ItemFeatureRepository : IItemFeatureRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public ItemFeatureRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public ItemFeature AddItemFeature(ItemFeature itemFeature)
        {
            _respayMLSDbContext.ItemFeatures.Add(itemFeature);

            _respayMLSDbContext.SaveChanges();

            return itemFeature;
        }

        public void Delete(int Id)
        {
            var getItemFeature = _respayMLSDbContext.ItemFeatures.Find(Id);

            _respayMLSDbContext.ItemFeatures.Remove(getItemFeature);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<ItemFeature> GetAllItemFeatures()
        {
            return _respayMLSDbContext.ItemFeatures.ToList();

        }

        public async Task<ICollection<ItemFeature>> GetAllItemFeatures(string navigation)
        {
            var getItemFeature = await _respayMLSDbContext.ItemFeatures.Include(navigation).ToListAsync();

            return getItemFeature;
        }

        public ItemFeature GetItemFeature(int Id)
        {
            var getItemFeature = _respayMLSDbContext.ItemFeatures.Find(Id);

            return getItemFeature;
        }

        public ItemFeature GetItemFeature(int Id, string navigation)
        {
            var getItemFeature = _respayMLSDbContext.ItemFeatures.Include(navigation).Where(x => x.ItemFeatureId == Id).FirstOrDefault();

            return getItemFeature;
        }

        public bool isItemFeatureExist(string featureName)
        {
            var isExist = _respayMLSDbContext.ItemFeatures.Where(x => x.FeatureName == featureName).Any();

            return isExist;
        }

        public ItemFeature UpdateItemFeature(ItemFeature itemFeature)
        {
            _respayMLSDbContext.Entry(itemFeature).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return itemFeature;
        }
    }
}
