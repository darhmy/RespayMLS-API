using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IItemTypeRepository
    {
        ItemType GetItemType(int Id);

        ItemType GetItemType(int Id, string navigation);

        Task<ICollection<ItemType>> GetItemSector(int sectorId);

        ICollection<ItemType> GetAllItemTypes();

        Task<ICollection<ItemType>> GetAllItemTypes(string navigation);

        ItemType AddItemType(ItemType itemType);

        ItemType UpdateItemType(ItemType itemType);

        void Delete(int Id);
    }
}
