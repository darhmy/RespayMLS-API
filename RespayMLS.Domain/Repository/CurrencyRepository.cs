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
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public CurrencyRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public Currency AddCurrency(Currency currency)
        {
            _respayMLSDbContext.Currencies.Add(currency);

            _respayMLSDbContext.SaveChanges();

            return currency;
        }

        public void Delete(int Id)
        {
            var getCurrency = _respayMLSDbContext.Currencies.Find(Id);

            _respayMLSDbContext.Currencies.Remove(getCurrency);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<Currency> GetAllCurrencies()
        {
            return _respayMLSDbContext.Currencies.ToList();
        }

        public Currency GetCurrency(int Id)
        {
            var getCurrency = _respayMLSDbContext.Currencies.Find(Id);

            return getCurrency;
        }

        public bool isCurrencyExist(string currencyName)
        {
            var isExist = _respayMLSDbContext.Currencies.Where(x => x.CurrencyName == currencyName).Any();

            return isExist;
        }

        public Currency UpdateCurrency(Currency currency)
        {
            _respayMLSDbContext.Entry(currency).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return currency;
        }
    }
}
