using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLetras;

namespace WebApp.Models
{
    public class NumberModel
    {
        public Double Value { get; set; }
        public int Type { get; set; }
        public string Letter { get; set; }
        public int Decimal { get; set; }
    }

    public static class FactoryModel
    {

        public static AbtsractLanguage GetLanguage(int index)
        {
            AbtsractLanguage lang ;
            switch (index)
            {
                case 0: lang = new SpanishLanguage(); break;
                case 1: lang = new EnglishLanguage(); break;
                case 2: lang = new RomanLanguage(); break;
                default: lang = new SpanishLanguage(); break;
            };

            return lang;
        }

    }
}
