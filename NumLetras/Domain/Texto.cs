
//--------------------------------------------------------------------------//
//                                                                          //
// ClassLetras por Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                                          //
// (Trujillo - Perú)                                                        //
//--------------------------------------------------------------------------//

    
namespace ClassLetras
{
    public enum TTexto
    { 
        eSimple,
        eCompuesta
    }

    public class Texto
    {
        
        private string TextoSimple { get; set; }
        private string TextoCompuesto { get; set; }

        public Texto(string textoSimple)
        {

            TextoSimple = textoSimple;
            TextoCompuesto = textoSimple;
        }

        public Texto(string textoSimple, string textoCompuesto)
        {
            TextoSimple = textoSimple;
            TextoCompuesto = textoCompuesto;
        }

        public string TokenTexto(TTexto eTLetra = TTexto.eSimple) => eTLetra == TTexto.eSimple ? TextoSimple : TextoCompuesto;

    }
}
