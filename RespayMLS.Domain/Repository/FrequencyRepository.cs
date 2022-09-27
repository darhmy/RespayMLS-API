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
    public class FrequencyRepository : IFrequencyRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public FrequencyRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public Frequency AddFrequency(Frequency frequency)
        {
            _respayMLSDbContext.Frequencies.Add(frequency);

            _respayMLSDbContext.SaveChanges();

            return frequency;
        }

        public void Delete(int Id)
        {
            var getFrequency = _respayMLSDbContext.Frequencies.Find(Id);

            _respayMLSDbContext.Frequencies.Remove(getFrequency);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<Frequency> GetAllFrequencies()
        {
            return _respayMLSDbContext.Frequencies.ToList();

        }

        public Frequency GetFrequency(int Id)
        {
            var getFrequency = _respayMLSDbContext.Frequencies.Find(Id);

            return getFrequency;
        }

        public bool isFrequencyExist(string frequencyName)
        {
            var isExist = _respayMLSDbContext.Frequencies.Where(x => x.FrequencyName == frequencyName).Any();

            return isExist;
        }

        public Frequency UpdateFrequency(Frequency frequency)
        {
            _respayMLSDbContext.Entry(frequency).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return frequency;
        }
    }
}
