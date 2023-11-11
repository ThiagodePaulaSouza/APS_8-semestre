using Microsoft.AspNetCore.Mvc;

namespace BuscarReciclaveis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuscarReciclaveisController : ControllerBase
    {
        public BuscarReciclaveisController()
        {
        }

        [HttpGet]
        [Route("/exemplo2")]
        public string Get()
        {
            return "exemplo 2";
        }
    }
}