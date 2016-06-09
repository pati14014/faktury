﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakturyA
{
    public class Article
    {
        //string[] unitMeasure={"usluga","sztuka","opakowanie","m2","kg","litr","m"};
        public string Code { get; private set; }
        public string Name { get; private set; }
        public decimal PriceNetto { get; private set; }
        public decimal PriceBrutto { get; private set; }
        public decimal VATvalue { get; private set; }
        public int Amount { get; set; } //ilosc
        public string UnitMeasure { get; private set; }// jednostka miary
        public decimal Discount { get; set; }

        public Article()
        {
            Code = "";
            Name = "";
            PriceNetto = 0.0M;
            PriceBrutto = 0.0M;
            VATvalue = 0.0m;
            UnitMeasure = "usluga";
            Discount = 0.0m;
            Amount = 0;
        }
        public Article(string[] row)
        {
            Code = row[0];
            Name = row[4];
            PriceNetto =Convert.ToDecimal(row[1]);
            VATvalue = Convert.ToDecimal(row[3])*100;
            PriceBrutto = PriceNetto + VATvalue;
            UnitMeasure = row[2];

        }
        public string GenerateQueryUpdateArticles()
        {
            return String.Format("Update artykul set cena_netto='{0}',jednostkaM='{1}',stawka_VAT='{2}',nazwa='{3}' where kod='{4}'", PriceNetto, UnitMeasure, VATvalue, Name, Code);
        }
        public string GenerateQueryInsertArticles()
        {
            return String.Format("Insert into artykul set kod='{0}', cena_netto='{1}',jednostkaM='{2}',stawka_VAT='{3}',nazwa='{4}'", Code, PriceNetto, UnitMeasure, VATvalue, Name);
        }

    }
}
