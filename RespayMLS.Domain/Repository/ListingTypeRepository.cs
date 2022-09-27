using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System.Collections.Generic;
using System.Linq;

namespace RespayMLS.Domain.Repository
{
    public class ListingTypeRepository : IListingTypeRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public ListingTypeRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public ListingType AddListingType(ListingType listingType)
        {
            _respayMLSDbContext.ListingTypes.Add(listingType);

            _respayMLSDbContext.SaveChanges();

            return listingType;
        }

        public void Delete(int Id)
        {
            var getListingType = _respayMLSDbContext.ListingTypes.Find(Id);

            _respayMLSDbContext.ListingTypes.Remove(getListingType);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<ListingType> GetAllListingTypes()
        {
            return _respayMLSDbContext.ListingTypes.ToList();

        }

        public ListingType GetListingType(int Id)
        {
            return _respayMLSDbContext.ListingTypes.Find(Id);

        }

        public ListingType UpdateListingType(ListingType listingType)
        {
            _respayMLSDbContext.Entry(listingType).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return listingType;
        }
    }
}
