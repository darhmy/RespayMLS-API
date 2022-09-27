using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System.Collections.Generic;
using System.Linq;

namespace RespayMLS.Domain.Repository
{
    public class ItemSubTypeRepository : IItemSubTypeRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public ItemSubTypeRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public ItemSubType AddItemSubType(ItemSubType itemSubType)
        {
            _respayMLSDbContext.ItemSubTypes.Add(itemSubType);

            _respayMLSDbContext.SaveChanges();

            return itemSubType;
        }

        public void Delete(int Id)
        {
            var getItemSubType = _respayMLSDbContext.ItemSubTypes.Find(Id);

            _respayMLSDbContext.ItemSubTypes.Remove(getItemSubType);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<ItemSubType> GetAllItemSubTypes()
        {
            return _respayMLSDbContext.ItemSubTypes.ToList();

        }

        public ItemSubType GetItemSubType(int Id)
        {
            return _respayMLSDbContext.ItemSubTypes.Find(Id);

        }

        public ItemSubType UpdateItemSubType(ItemSubType itemSubType)
        {
            _respayMLSDbContext.Entry(itemSubType).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return itemSubType;
        }
    }
}
