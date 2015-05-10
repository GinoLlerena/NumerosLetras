
//--------------------------------------------------------------------------//
//                                                                          //
// ClassLetras por Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                                          //
// (Trujillo - Perú)                                                        //
//--------------------------------------------------------------------------//


using System;
using System.Collections.Generic;

namespace ClassLetras
{
    public class NumberToLetters
    {
        #region private fields

        Queue<string> aNumbers = new Queue<string>();
        StackToken StackTokens = new StackToken();
        AbtsractLanguage language = null;
        double nNumber;
        string ParteEntera;
        string ParteDecimal;
        
        #endregion

        #region properties

        public bool ShowDecimals {get;set;}
        

        public double Number
        {
            get { return nNumber; }
            set { 
                nNumber  = value;
                if (nNumber != 0)
                    ProcesaNumero(); 
            }
        }

        public AbtsractLanguage Language
        {
            get { 
                if(language == null)
                    language = new SpanishLanguage();
                return language; 
            }
            set { 
                language = value;
                if (nNumber != 0)
                    ProcesaNumero(); 
            }
        }

        #endregion

        #region Constructos

        public NumberToLetters()
        {
            nNumber = 0;
        }

        #endregion

        #region private methods

        private void ClearData()
        {
            aNumbers.Clear();
            StackTokens.Clear(); 
        }

        private void ProcesaNumero()
        {
            ClearData();

            string sNumber = nNumber.ToString();

            int i = sNumber.IndexOf('.');
            if (i != -1){
                ParteEntera = sNumber.Substring(0,i);
                ParteDecimal = sNumber.Substring(i + 1) ;
            }
            else{
                ParteEntera = sNumber;
                ParteDecimal = "";
            }

            if (ParteEntera.Length >= 3){
                int iMod = ParteEntera.Length % 3;
                int iIter = ParteEntera.Length / 3;
                string sTem;
                string sCifra = ParteEntera;

                for (i = iIter * 3 - 3 + iMod; i >= 0; i -= 3){
                    sTem = sCifra.Substring(i);
                    sCifra = sCifra.Substring(0, i);
                    aNumbers.Enqueue(sTem);
                }

                if (sCifra.Length >0 )
                    aNumbers.Enqueue(sCifra);
            }
            else
                aNumbers.Enqueue(ParteEntera);
            

            ProcesaQueue();

       }

        private void ProcesaQueue()
        {
            int j = 0; 
            foreach (string s in aNumbers)
                j = ProcesaDigitos(s, j);
        }


        private int ProcesaDigitos(string s, int j)
        {
            
            StackToken _stack = new StackToken();
            _stack.OnAction += (x,y) => StackTokens.Push(y.token);


            if (Language.Exists(s)){
                _stack.Push(new Token(int.Parse(s), Language));
            }
            else{
                _stack.Push(new Token(int.Parse(s.Substring(0, 1)), Language));
                if (Language.Exists(s.Substring(1))){
                    _stack.Push(new Token(int.Parse(s.Substring(1)), Language));
                }
                else{
                    _stack.Push(new Token(int.Parse(s.Substring(1, 1)), Language));
                    if (Language.Exists(s.Substring(2)))
                        _stack.Push(new Token(int.Parse(s.Substring(2)), Language));
                    else
                        _stack.Push(new Token(int.Parse(s.Substring(2, 1)), Language));
                }
            }

            return _stack.Process(s.Length, j);  
        }

        #endregion

        #region public methods

        public List<Token> GetList() => StackTokens.GetList();
        
        public string GetNumberToLetters() => StackTokens.GetLettersTogether() + (ShowDecimals ? Language.Connector + (ParteDecimal.Length == 0 ? "00" : ParteDecimal) + "/100" : string.Empty);
        
        #endregion
    }
}
