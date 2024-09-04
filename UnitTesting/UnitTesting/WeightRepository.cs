using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public class WeightRepository: IDataRepository
    {
        public List<WeightCalculater> WeightCalculaterList { get; set; }
       public WeightRepository()
        {
            this.WeightCalculaterList = new List<WeightCalculater>()
            {
                new WeightCalculater(175,"f"),//62.5
                new WeightCalculater(167,"m"),//62.75
                new WeightCalculater(182,"m"),//74
            };
        }

        public IEnumerable<WeightCalculater> GetWeightcalculators()
        {
            return this.WeightCalculaterList;
        }
    }
}
