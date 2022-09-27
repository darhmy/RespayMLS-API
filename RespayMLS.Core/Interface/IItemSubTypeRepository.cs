using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IItemSubTypeRepository
    {
        ItemSubType GetItemSubType(int Id);

        ICollection<ItemSubType> GetAllItemSubTypes();

        ItemSubType AddItemSubType(ItemSubType itemSubType);

        ItemSubType UpdateItemSubType(ItemSubType itemSubType);

        void Delete(int Id);
    }
}
