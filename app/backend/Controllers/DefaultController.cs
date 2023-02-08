using backend.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace backend.Controllers
{
    /// <summary>
    /// default
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]    
    public class DefaultController : Controller
    {
        /// <summary>
        /// HealthCheck to make sure the service is up.
        /// </summary>    
        /// <response code="200"> The service is up and running. </response>    
        /// <returns></returns>
        [ProducesResponseType(200)]      
        [HttpGet("/ping")]
        public string Get()
        {
            return "pong";
        }

        /// <summary>
        /// Return aggregated creadit data      
        /// </summary>    
        /// <param name="ssn" example="424-11-9327"></param>
        /// <response code="200">Aggregated credit data for given ssn.</response>
        /// <response code="404">Credit data not found for given ssn.</response> 
        [HttpGet("/credit-data/{ssn}")]
        [ProducesResponseType(typeof(CreditData),200)]
        
      
    
        public async Task<IActionResult> GetCreditData(string ssn)
        {
            return Ok(new CreditData("Test","LastName","Address",1,1,true));
        }
    }
}
