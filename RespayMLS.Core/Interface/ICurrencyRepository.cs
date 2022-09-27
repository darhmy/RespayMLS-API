using RespayMLS.Core.Models;
using System.Collections.Generic;

namespace RespayMLS.Core.Interface
{
    public interface ICurrencyRepository
    {
        Currency GetCurrency(int Id);

        ICollection<Currency> GetAllCurrencies();

        Currency AddCurrency(Currency currency);

        Currency UpdateCurrency(Currency currency);

        void Delete(int Id);

        bool isCurrencyExist(string currencyName);

    }
}
