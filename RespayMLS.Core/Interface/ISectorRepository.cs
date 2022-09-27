using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface ISectorRepository
    {
        Sector GetSector(int Id);

        ICollection<Sector> GetAllSectors();

        Sector AddSector(Sector sector);

        Sector Update(Sector sector);

        void Delete(int Id);

        bool isSectorExist(string sectorName);

    }
}
