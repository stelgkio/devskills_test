using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PingController : Controller
    {
        /// <summary>
        /// HealthCheck to make sure the service is up.
        /// </summary>    
        /// <response code="200"> The service is up and running. </response>    
        /// <returns></returns>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet]
        public string Get()
        {
            return "pong";
        }

        /// <summary>
        /// Return aggregated creadit data      
        /// </summary>    
        /// <param name="ssn" example="424-11-9327"></param>
        /// <response code="200">Aggregated credit data for given ssn.</response>
        /// <response code="400">Credit data not found for given ssn.</response> 
        [HttpGet("/credit-data/{ssn}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public string GetCreditData(string ssn)
        {
            return ;
        }
    }
}
