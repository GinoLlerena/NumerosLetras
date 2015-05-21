using System.Collections.Generic;

namespace ClassLetras
{
    public class RomanLanguage : AbtsractLanguage 
    {

        public RomanLanguage()
            : base(InitializeLetras(), InitializeExceptions())
        {


        }

        private static Dictionary<string, Texto> InitializeLetras()
        {
            Dictionary<string, Texto> aLetras = new Dictionary<string, Texto>();

            aLetras.Add("1", new Texto("I"));
            aLetras.Add("2", new Texto("II"));
            aLetras.Add("3", new Texto("III"));
            aLetras.Add("4", new Texto("IV"));
            aLetras.Add("5", new Texto("V"));
            aLetras.Add("6", new Texto("VI"));
            aLetras.Add("7", new Texto("VII"));
            aLetras.Add("8", new Texto("VIII"));
            aLetras.Add("9", new Texto("IX"));
            aLetras.Add("10", new Texto("X"));
            aLetras.Add("20", new Texto("XX"));
            aLetras.Add("30", new Texto("XXX"));
            aLetras.Add("40", new Texto("XL"));
            aLetras.Add("50", new Texto("L"));
            aLetras.Add("60", new Texto("LX"));
            aLetras.Add("70", new Texto("LXX"));
            aLetras.Add("80", new Texto("LXXX"));
            aLetras.Add("90", new Texto("XC"));
            aLetras.Add("100", new Texto("C"));
            aLetras.Add("200", new Texto("CC"));
            aLetras.Add("300", new Texto("CCC"));
            aLetras.Add("400", new Texto("CD"));
            aLetras.Add("500", new Texto("D"));
            aLetras.Add("600", new Texto("DC"));
            aLetras.Add("700", new Texto("DCC"));
            aLetras.Add("800", new Texto("DCCC"));
            aLetras.Add("900", new Texto("CM"));
            aLetras.Add("1000", new Texto("M"));
            aLetras.Add("2000", new Texto("MM"));
            aLetras.Add("3000", new Texto("MMM"));

            return aLetras;
        }

        private static List<string> InitializeExceptions()
        {
            List<string> lstExcepciones = new List<string>();
            return lstExcepciones;
        }

        protected override TTexto Rules(int iExp, int iItera) 
        {
            return TTexto.eSimple ;
        }

        protected override string GetAdditionalLetters(int iExp, int iItera)
        {
            return string.Empty;
        }

        public override string Connector
        {
            get { return string.Empty; }
        }
    }
}
