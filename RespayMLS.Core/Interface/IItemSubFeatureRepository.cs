using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IItemSubFeatureRepository
    {
        ItemSubFeature GetItemSubFeature(int Id);

        ItemSubFeature GetItemSubFeature(int Id, string navigation);

        //Task<ICollection<ItemSubFeature>> GetItemSector(int sectorId);

        ICollection<ItemSubFeature> GetAllItemSubFeatures();

        Task<ICollection<ItemSubFeature>> GetAllItemSubFeatures(string navigation);

        ItemSubFeature AddItemSubFeature(ItemSubFeature itemSubFeature);

        ItemSubFeature UpdateItemSubFeature(ItemSubFeature itemSubFeature);

        void Delete(int Id);

        bool isItemSubFeatureExist(string roleName);

    }
}
