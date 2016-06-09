using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fakturyA
{
    public class ArticleOnInvoice
    {
        private decimal discount;
        private decimal amount; 

        public Article Article { get; private set; }
        public decimal Discount { get{ return discount; }
            set
            {
                discount = value;
                UpdateValues();
            }
        }
        public decimal Amount { get{ return amount; }
            set
            {
                amount = value;
                UpdateValues();
            }
        }
        public decimal ValueNetto { get; private set; }
        public decimal ValueBrutto { get; private set; }

        public ArticleOnInvoice(Article article, decimal discount, decimal amount)
        {
            Article = article;
            Discount = discount;
            Amount = amount; 
        }

        private void UpdateValues()
        {
            ValueNetto = Math.Round(Amount * (1-Discount*0.01m) * Article.PriceNetto,2);
            ValueBrutto = Math.Round(Amount * (1-Discount*0.01m) * Article.PriceBrutto,2);
        }

        public void WriteDataToRow()
        {

        }
    }
}
