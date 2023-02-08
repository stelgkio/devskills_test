using backend.Contracts;
using backend.Feature;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Produces("application/json")]    
    public class DefaultController : ApiController
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
            var query= new SSN(ssn);
            CreditData result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
