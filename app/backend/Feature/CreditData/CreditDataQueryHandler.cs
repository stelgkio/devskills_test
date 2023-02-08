using backend.Contracts;
using backend.Infastructure;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace backend.Feature
{

    public class SSN : BaseCqrsRequest<CreditData>
    {
        public SSN(string ssn):base()
        {
            this.ssn = ssn;
        }

        public string ssn { get; set; }

    }

    public class CreditDataQueryHandler : IRequestHandler<SSN, CreditData>
    {
        private readonly ILogger<CreditDataQueryHandler> _logger;
      
        public Task<CreditData> Handle(SSN request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
