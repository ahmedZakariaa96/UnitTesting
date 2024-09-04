using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
   public class WeightCalculater
    {

        public double Height { get; set; }
        public string gander { get; set; }
        private readonly IDataRepository rep;

        public WeightCalculater()
        {
        }
        public WeightCalculater(double h,string g)
        {
            this.Height = h;
            this.gander = g;
        }
        public WeightCalculater(IDataRepository rep)
        {
            this.rep = rep;
        }
        public double GetIdealWeight()
        {
            switch (gander)
            {
                case "m":
                    return (this.Height - 100) - ((this.Height - 150) / 4);
                case "f":
                    return (this.Height - 100) - ((this.Height - 150) / 2);
                default:
                    throw new ArgumentException("The gander is not defined");
            }
        }

        public List<double>GetIdealBodyWeightFormDataSource()
        {
            List<double> res = new List<double>();

            IEnumerable<WeightCalculater> WeightCalculaters = this.rep.GetWeightcalculators();

            foreach (var item in WeightCalculaters)
            {
                res.Add(item.GetIdealWeight());
            }
            return res;
        }

        public bool validate()
        {
            return this.gander.ToLower() == "m" || this.gander.ToLower() == "f";
        }
    }
}
