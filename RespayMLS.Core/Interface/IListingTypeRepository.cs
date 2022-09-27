using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IListingTypeRepository
    {
        ListingType GetListingType(int Id);

        ICollection<ListingType> GetAllListingTypes();

        ListingType AddListingType(ListingType listingType);

        ListingType UpdateListingType(ListingType listingType);

        void Delete(int Id);
    }
}
