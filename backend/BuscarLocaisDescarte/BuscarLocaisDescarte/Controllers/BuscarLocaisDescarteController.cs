using Microsoft.AspNetCore.Mvc;

namespace BuscarLocaisDescarte.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuscarLocaisDescarteController : ControllerBase
    {
        public BuscarLocaisDescarteController()
        {
        }

        [HttpGet]
        [Route("/exemplo1")]
        public string Get()
        {
            return "exemplo1 response";
        }
    }
}