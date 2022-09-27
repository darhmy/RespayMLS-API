using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Domain.Repository
{
    public class SectorRepository : ISectorRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public SectorRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public Sector AddSector(Sector sector)
        {
            _respayMLSDbContext.Sectors.Add(sector);
            _respayMLSDbContext.SaveChanges();

            return sector;
        }

        public void Delete(int Id)
        {
            var getSector = _respayMLSDbContext.Sectors.Find(Id);

            _respayMLSDbContext.Sectors.Remove(getSector);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<Sector> GetAllSectors()
        {
            return _respayMLSDbContext.Sectors.ToList();
        }

        public Sector GetSector(int Id)
        {
            var getSector = _respayMLSDbContext.Sectors.Find(Id);

            return getSector;
        }

        public bool isSectorExist(string sectorName)
        {
            var isExist = _respayMLSDbContext.Sectors.Where(x => x.SectorName == sectorName).Any();

            return isExist;
        }

        public Sector Update(Sector sector)
        {
            _respayMLSDbContext.Entry(sector).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return sector;
        }
    }
}
