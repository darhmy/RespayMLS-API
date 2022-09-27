using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IItemFeatureRepository
    {
        ItemFeature GetItemFeature(int Id);

        ItemFeature GetItemFeature(int Id, string navigation);

        //Task<ICollection<ItemFeature>> GetItemSector(int sectorId);

        ICollection<ItemFeature> GetAllItemFeatures();

        Task<ICollection<ItemFeature>> GetAllItemFeatures(string navigation);

        ItemFeature AddItemFeature(ItemFeature itemFeature);

        ItemFeature UpdateItemFeature(ItemFeature itemFeature);

        void Delete(int Id);

        bool isItemFeatureExist(string featureName);

    }
}
