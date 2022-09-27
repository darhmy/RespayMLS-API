using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespayMLS.Domain.Repository
{
    public class ItemSubFeatureRepository : IItemSubFeatureRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public ItemSubFeatureRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public ItemSubFeature AddItemSubFeature(ItemSubFeature itemSubFeature)
        {
            _respayMLSDbContext.ItemSubFeatures.Add(itemSubFeature);

            _respayMLSDbContext.SaveChanges();

            return itemSubFeature;
        }

        public void Delete(int Id)
        {
            var getItemSubFeature = _respayMLSDbContext.ItemSubFeatures.Find(Id);

            _respayMLSDbContext.ItemSubFeatures.Remove(getItemSubFeature);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<ItemSubFeature> GetAllItemSubFeatures()
        {
            return _respayMLSDbContext.ItemSubFeatures.ToList();

        }

        public async Task<ICollection<ItemSubFeature>> GetAllItemSubFeatures(string navigation)
        {
            var getItemSubFeature = await _respayMLSDbContext.ItemSubFeatures.Include(navigation).ToListAsync();

            return getItemSubFeature;
        }

        public ItemSubFeature GetItemSubFeature(int Id)
        {
            var getItemSubFeature = _respayMLSDbContext.ItemSubFeatures.Find(Id);

            return getItemSubFeature;
        }

        public ItemSubFeature GetItemSubFeature(int Id, string navigation)
        {
            var getItemSubFeature = _respayMLSDbContext.ItemSubFeatures.Include(navigation).Where(x => x.ItemSubFeatureId == Id).FirstOrDefault();

            return getItemSubFeature;
        }

        public bool isItemSubFeatureExist(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public ItemSubFeature UpdateItemSubFeature(ItemSubFeature itemSubFeature)
        {
            _respayMLSDbContext.Entry(itemSubFeature).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return itemSubFeature;
        }
    }
}
