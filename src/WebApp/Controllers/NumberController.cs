using Microsoft.AspNet.Mvc;
using WebApp.Models;
using ClassLetras;


namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class NumberController : Controller
    {
        
        [HttpPost]
        public string Post([FromBody] NumberModel number)
        {
            NumberToLetters process = new NumberToLetters();
            string scadena = string.Empty;

            if (ModelState.IsValid)
            {
                process.Language = FactoryModel.GetLanguage(number.Type);
                process.Number = number.Value;
                process.ShowDecimals = (number.Decimal == 0 ? false : true);
                scadena = process.GetNumberToLetters();
            }

            return scadena;
        }

    }
}
