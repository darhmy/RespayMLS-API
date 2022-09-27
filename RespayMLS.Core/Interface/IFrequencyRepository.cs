using System.Collections.Generic;
using RespayMLS.Core.Models;

namespace RespayMLS.Core.Interface
{
    public interface IFrequencyRepository
    {
        Frequency GetFrequency(int Id);

        ICollection<Frequency> GetAllFrequencies();

        Frequency AddFrequency(Frequency frequency);

        Frequency UpdateFrequency(Frequency frequency);

        void Delete(int Id);

        bool isFrequencyExist(string frequencyName);

    }
}
