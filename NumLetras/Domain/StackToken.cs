
//--------------------------------------------------------------------------//
//                                                                          //
// ClassLetras por Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                                          //
// (Trujillo - Perú)                                                        //
//--------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLetras
{

    public class StackArgs : EventArgs 
    {
        public StackArgs(Token c)
        {
            token = c;
        }
        public Token token;    
    }


    public class StackToken : Stack<Token>
    {
        public event EventHandler<StackArgs> OnAction;

        public int Process(int length,  int j)
        {
            int n = this.Count;
            int i = -1;

            while (this.Count > 0){

                Token c = this.Pop();
               
                i = InnerProcess(i, length, n, c);
                c.Exponent = i + j;
                c.Iteration = n;

                if (!(c.TokenNumber == 0))
                    OnAction?.Invoke(this, new StackArgs(c));
                else
                    n -= 1;
            }

            if (length == 3){
                switch (i) {
                    case 0: j += 3; break;
                    case 1: j += 2; break;
                    case 2: j += 1; break;
                }
                j = j + i;
            }

            return j;

        }

        private int InnerProcess(int i, int length, int n, Token c)
        {
            if (length == 3) {
                if ((n == 1) && c.TokenNumber.ToString().Trim().Length == 3)
                    i = 0;
                
                if ((n == 2) && c.TokenNumber.ToString().Trim().Length == 2)
                    i = 0;

                if ((n == 2) && c.TokenNumber.ToString().Trim().Length == 1)
                    i = 2;
                
                if ((n == 3) && c.TokenNumber.ToString().Trim().Length == 1)
                    i += 1;
            }
            else 
                if ((n == 1) && (length == 2) && c.TokenNumber.ToString().Trim().Length == 2)
                    i = 0;
                else
                    if ((n == 2) && (length == 2) && c.TokenNumber.ToString().Trim().Length == 1)
                        i += 1;
                    else
                        i = 0;

            return i;

        }

        public List<Token> GetList() =>  this.ToList();
        
        public string GetLettersTogether() => String.Join("", this.Select(x => x.TokenLetter));  

    }
}
