
//--------------------------------------------------------------------------//
//                                                                          //
// ClassLetras por Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                                          //
// (Trujillo - Perú)                                                        //
//--------------------------------------------------------------------------//

using static System.Math;

namespace ClassLetras
{
    public class Token
    {
        
        AbtsractLanguage Lenguage;

        public Token(int numero, AbtsractLanguage lenguage)
        {
            TokenNumber = numero;
            Lenguage = lenguage;
        }

        public int TokenNumber {get; set;}
        public int Iteration {get;set;}
        public int Exponent {get;set;}
        
        public int IteractionNumber
        {
            get { return TokenNumber * ((int)Pow(10, (Exponent % 3))); }
        }

        public long ExponentialNumber
        {
            get { return TokenNumber * ((long)Pow(10, Exponent)); }
        }

        public string TokenLetter
        {
            get
            {
                string sLetraRetorno = string.Empty;
                sLetraRetorno = Lenguage.GetDefinition(ExponentialNumber.ToString(), Exponent, Iteration);

                if (sLetraRetorno.Length == 0)
                    sLetraRetorno = Lenguage.GetDefinition(IteractionNumber.ToString(), Exponent, Iteration);

                if (sLetraRetorno.Length == 0)
                    sLetraRetorno = Lenguage.GetDefinition(TokenNumber.ToString(), Exponent, Iteration);
             
                return sLetraRetorno;

            }
        }

    }   

}
