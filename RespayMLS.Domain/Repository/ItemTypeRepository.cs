using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Domain.Repository
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public ItemTypeRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public ItemType AddItemType(ItemType itemType)
        {
            _respayMLSDbContext.ItemTypes.Add(itemType);

            _respayMLSDbContext.SaveChanges();

            return itemType;
        }

        public void Delete(int Id)
        {
            var getItemType = _respayMLSDbContext.ItemTypes.Find(Id);

            _respayMLSDbContext.ItemTypes.Remove(getItemType);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<ItemType> GetAllItemTypes()
        {
            return _respayMLSDbContext.ItemTypes.ToList();
        }

        public async Task<ICollection<ItemType>> GetAllItemTypes(string navigation)
        {
            var getItemTypes = await _respayMLSDbContext.ItemTypes.Include(navigation).ToListAsync();

            return getItemTypes;
        }

        public ItemType GetItemType(int Id)
        {
            var getItemType = _respayMLSDbContext.ItemTypes.Find(Id);

            return getItemType;
        }

        public async Task<ICollection<ItemType>> GetItemSector(int sectorId)
        {
           return await _respayMLSDbContext.ItemTypes.Where(x => x.Sector.SectorId == sectorId).ToListAsync();
        }

        public ItemType GetItemType(int Id, string navigation)
        {
            var getItemType = _respayMLSDbContext.ItemTypes.Include(navigation).Where(x => x.ItemTypeId == Id).FirstOrDefault();

            return getItemType;
        }

        public ItemType UpdateItemType(ItemType itemType)
        {
            _respayMLSDbContext.Entry(itemType).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return itemType;
        }
    }
}
