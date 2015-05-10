
//--------------------------------------------------------------------------//
//                                                                          //
// ClassLetras por Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                                          //
// (Trujillo - Perú)                                                        //
//--------------------------------------------------------------------------//


using System.Collections.Generic;

namespace ClassLetras
{
    public class EnglishLanguage : AbtsractLanguage 
    {

        public EnglishLanguage()
            : base(InitializeLetras(), InitializeExceptions())
        {


        }


        private static Dictionary<string, Texto> InitializeLetras()
        {
            Dictionary<string, Texto> aLetras = new Dictionary<string,Texto>();

            aLetras.Add("1", new Texto("one"));
            aLetras.Add("2", new Texto("two"));
            aLetras.Add("3", new Texto("three"));
            aLetras.Add("4", new Texto("four"));
            aLetras.Add("5", new Texto("five"));
            aLetras.Add("6", new Texto("six"));
            aLetras.Add("7", new Texto("seven"));
            aLetras.Add("8", new Texto("eight"));
            aLetras.Add("9", new Texto("nine"));
            aLetras.Add("10", new Texto("ten"));
            aLetras.Add("11", new Texto("eleven"));
            aLetras.Add("12", new Texto("twelve"));
            aLetras.Add("13", new Texto("thirteen"));
            aLetras.Add("14", new Texto("fourteen"));
            aLetras.Add("15", new Texto("fifteen"));
            aLetras.Add("16", new Texto("sixteen"));
            aLetras.Add("17", new Texto("fifteen"));
            aLetras.Add("18", new Texto("eighteen"));
            aLetras.Add("19", new Texto("nineteen "));
            aLetras.Add("20", new Texto("twenty "));
            aLetras.Add("30", new Texto("thirty "));
            aLetras.Add("40", new Texto("forty "));
            aLetras.Add("50", new Texto("fifty "));
            aLetras.Add("60", new Texto("sixty "));
            aLetras.Add("70", new Texto("seventy "));
            aLetras.Add("80", new Texto("eighty "));
            aLetras.Add("90", new Texto("ninety "));
            aLetras.Add("100", new Texto("hundred ", " hundred and "));
            aLetras.Add("1000", new Texto("thousand ", "thousand and "));
            aLetras.Add("1000000", new Texto("million ", "millions "));
            
            
            return aLetras;
        }
                      
        private static List<string> InitializeExceptions()
        {
            List<string> lstExcepciones  = new List<string>();
            lstExcepciones.Add("100");
            lstExcepciones.Add("1000");
            lstExcepciones.Add("1000000");
            lstExcepciones.Add("1000000000");

            return lstExcepciones;
        }

        
        protected override TTexto Rules(int iExp, int iItera)
        { 
            TTexto eLetra= TTexto.eCompuesta;

            if ((iExp == 0 || (iExp % 3 == 0)) && iItera > 2) 
                eLetra = TTexto.eSimple;
            if ((iExp == 0 || (iExp % 3 == 0)) && iItera == 1) 
                eLetra = TTexto.eSimple;
            if (iExp == 6 && TokenNumber == "1000000" && iItera > 1) 
                eLetra = TTexto.eCompuesta;
            if (iExp == 3 && iItera == 3  && TokenNumber == "1") 
                eLetra = TTexto.eCompuesta;
            if (iExp == 3 && iItera == 1 && TokenNumber == "1") 
                eLetra = TTexto.eCompuesta;
            if ((iExp == 0 || (iExp % 3 == 0)) && iItera == 2 && TokenNumber.Length == 2) 
                eLetra = TTexto.eSimple;
            
            return eLetra;  
        
        }


        protected override string GetAdditionalLetters(int iExp, int iItera)
        {
            string sLetraRetorno = "";

            if (!IsExcepcion())
            {
                if (iExp == 2)
                    sLetraRetorno += " hundred ";
                if (iExp == 3 && iItera == 1)
                    sLetraRetorno += " thousands ";
                if (iExp == 3 && iItera == 2)
                    sLetraRetorno += " thousands ";
                if (iExp == 3 && iItera == 3)
                    sLetraRetorno += " thousands ";
                if (iExp == 4 && iItera == 1)
                    sLetraRetorno += " thousands ";
                if (iExp == 5 && iItera == 1)
                    sLetraRetorno += " hundred thousands ";
                if (iExp == 5 && iItera == 2)
                    sLetraRetorno += " hundred ";
                if (iExp == 5 && iItera == 3)
                    sLetraRetorno += " hundred ";
                if (iExp == 6 && iItera == 1)
                    sLetraRetorno += " millions ";
                if (iExp == 6 && iItera == 2)
                    sLetraRetorno += " millions ";
                if (iExp == 6 && iItera == 3)
                    sLetraRetorno += " millions ";
                if (iExp == 8 && iItera == 2)
                    sLetraRetorno += " hundred ";
                if (iExp == 8 && iItera == 3)
                    sLetraRetorno += " hundred ";
                if (iExp == 9 && iItera == 1)
                    sLetraRetorno += " thousands ";
                if (iExp == 9 && iItera == 2)
                    sLetraRetorno += " hundred thousands ";
            }

            return sLetraRetorno;
        }

        public override string Connector
        {
            get { return " and "; }
        }
    }
}
