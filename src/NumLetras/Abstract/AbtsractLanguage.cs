
//--------------------------------------------------------------------------//
//                                                                          //
// ClassLetras por Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                                          //
// (Trujillo - Perú)                                                        //
//--------------------------------------------------------------------------//

using System.Collections.Generic;

namespace ClassLetras
{
    public abstract class AbtsractLanguage
    {
        public Dictionary<string, Texto> Letras { get; set; }
        public List<string> Excepciones { get; set; }
        protected string TokenNumber { get; set; } = "0";

        public AbtsractLanguage(Dictionary<string, Texto> _aLetras, List<string> _lstExcepciones)
        {
            Letras = _aLetras;
            Excepciones = _lstExcepciones;
        }

        public AbtsractLanguage(string psKeyNumber, Dictionary<string, Texto> _aLetras, List<string> _lstExcepciones)
        {
            psKeyNumber = TokenNumber;
            Letras = _aLetras;
            Excepciones = _lstExcepciones;
        }
             
        protected bool IsExcepcion() => Excepciones.Exists(x => x == TokenNumber);
        
        public bool Exists(string iNumber) => (GetDefinition(iNumber).Length > 0);
        
        protected string GetDefinition(string iNumber, TTexto eTLetra = TTexto.eSimple)
        {
            Texto cLetra;
            TokenNumber = iNumber.ToString().Trim();
            bool bBan = Letras.TryGetValue(iNumber, out cLetra);
            if (bBan)
                return cLetra.TokenTexto(eTLetra);
            else
                return string.Empty;
        }

        public string GetDefinition(string iNumber, int iExp, int iItera)
        {
            string sCadena;
            TokenNumber = iNumber.ToString().Trim();
            sCadena = GetDefinition(iNumber, Rules(iExp, iItera));
            return sCadena.Length > 0 ? sCadena + GetAdditionalLetters(iExp, iItera) : string.Empty;
        }

        protected abstract TTexto Rules(int iExp, int iItera);
        
        protected abstract string GetAdditionalLetters(int iExp, int iItera) ;

        public abstract string Connector { get;}
    }
}
