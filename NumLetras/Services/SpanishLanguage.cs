
//--------------------------------------------------------------------------//
//                                                                          //
// ClassLetras por Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                                          //
// (Trujillo - Perú)                                                        //
//--------------------------------------------------------------------------//


using System.Collections.Generic;

namespace ClassLetras
{
    public class SpanishLanguage : AbtsractLanguage 
    {

        public SpanishLanguage()
            : base(InitializeLetras(), InitializeExceptions())
        {


        }

        private static Dictionary<string, Texto> InitializeLetras()
        {
            Dictionary<string, Texto> aLetras = new Dictionary<string, Texto>();

            
            aLetras.Add("1", new Texto("uno", "un"));
            aLetras.Add("2", new Texto("dos"));
            aLetras.Add("3", new Texto("tres"));
            aLetras.Add("4", new Texto("cuatro"));
            aLetras.Add("5", new Texto("cinco"));
            aLetras.Add("6", new Texto("seis"));
            aLetras.Add("7", new Texto("siete"));
            aLetras.Add("8", new Texto("ocho"));
            aLetras.Add("9", new Texto("nueve"));
            aLetras.Add("10", new Texto("diez", "dieci"));
            aLetras.Add("11", new Texto("once"));
            aLetras.Add("12", new Texto("doce"));
            aLetras.Add("13", new Texto("trece"));
            aLetras.Add("14", new Texto("catorce"));
            aLetras.Add("15", new Texto("quince"));
            aLetras.Add("20", new Texto("veinte", "veinti"));
            aLetras.Add("30", new Texto("treinta", "treinta y "));
            aLetras.Add("40", new Texto("cuarenta", "cuarenta y "));
            aLetras.Add("50", new Texto("cincuenta", "cincuenta y "));
            aLetras.Add("60", new Texto("sesenta", "sesenta y "));
            aLetras.Add("70", new Texto("setenta", "setenta y "));
            aLetras.Add("80", new Texto("ochenta", "ochenta y "));
            aLetras.Add("90", new Texto("noventa", "noventa y "));
            aLetras.Add("100", new Texto("cien", "ciento "));
            aLetras.Add("500", new Texto("quinientos "));
            aLetras.Add("900", new Texto("novecientos "));
            aLetras.Add("1000000", new Texto("un millon ", "un millones "));
            aLetras.Add("1000000000", new Texto("un mil millones "));

       
            return aLetras;

        }

        private static List<string> InitializeExceptions()
        {
            List<string> lstExcepciones = new List<string>();

            lstExcepciones.Add("100");
            lstExcepciones.Add("500");
            lstExcepciones.Add("900");
            lstExcepciones.Add("1000000");
            lstExcepciones.Add("1000000000");


            return lstExcepciones;
        }




        protected override TTexto Rules(int iExp, int iItera)
        {
            TTexto eLetra = TTexto.eCompuesta;

            if ((iExp == 0 || (iExp % 3 == 0)) && iItera > 2) 
                eLetra = TTexto.eSimple;
            if ((iExp == 0 || (iExp % 3 == 0)) && iItera == 1)
                eLetra = TTexto.eSimple;
            if (iExp == 6 &&  iItera > 1)
                eLetra = TTexto.eCompuesta;
            if (iExp == 3 && iItera == 3 && TokenNumber == "1") 
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
                if (iExp == 2 )
                    sLetraRetorno += "cientos ";
                if (iExp == 3 && iItera == 1)
                    sLetraRetorno += " mil ";
                if (iExp == 3 && iItera == 2)
                    sLetraRetorno += " mil ";
                if (iExp == 3 && iItera == 3)
                    sLetraRetorno += " mil ";
                if (iExp == 4 && iItera == 1)
                    sLetraRetorno += " mil ";
                if (iExp == 5 && iItera == 1)
                    sLetraRetorno += "cientos mil ";
                if (iExp == 5 && iItera == 2 )
                    sLetraRetorno += "cientos ";
                if (iExp == 5 && iItera == 3 )
                    sLetraRetorno += "cientos ";
                if (iExp == 6 && iItera == 1 )
                    sLetraRetorno += " millones ";
                if (iExp == 6 && iItera == 2 )
                    sLetraRetorno += " millones ";
                if (iExp == 6 && iItera == 3 )
                    sLetraRetorno += " millones ";
                if (iExp == 8 && iItera == 2 )
                    sLetraRetorno += "cientos ";
                if (iExp == 8 && iItera == 3 )
                    sLetraRetorno += "cientos ";
                if (iExp == 9 && iItera == 1 )
                    sLetraRetorno += " mil ";
                if (iExp == 9 && iItera == 2 )
                    sLetraRetorno += "cientos mil ";
            }

            return sLetraRetorno;
        }

        public override string Connector
        {
            get { return " y "; }
        }
    }
}
