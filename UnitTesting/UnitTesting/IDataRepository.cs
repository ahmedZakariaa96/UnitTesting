using System.Collections.Generic;

namespace UnitTesting
{
    public interface IDataRepository
    {
        IEnumerable<WeightCalculater> GetWeightcalculators();


    }
}
