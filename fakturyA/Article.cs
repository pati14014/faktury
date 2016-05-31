using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakturyA
{
    class Article
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public double PriceNetto { get; private set; }
        public double VATvalue { get; private set; }
        public string PriceBrutto { get; private set; }
        public float Amount { get; set; }
        //public double PriceBrutto { get; private set; }

        public Article(string code)
        {

        }
    }
}
