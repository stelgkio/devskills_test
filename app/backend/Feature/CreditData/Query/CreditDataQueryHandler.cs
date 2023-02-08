﻿using backend.Contracts;
using backend.Infastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace backend.Feature
{

    public class SSN : BaseCqrsRequest<CreditData>
    {
        public SSN(string ssn) : base()
        {
            this.Ssn = ssn;
        }

        public string Ssn { get; set; }

    }

    public class CreditDataQueryHandler : IRequestHandler<SSN, CreditData>
    {
        private readonly HttpClient _httpClien;
        private readonly ILogger<CreditDataQueryHandler> _logger;
        private readonly IConfiguration _configuration;

        public CreditDataQueryHandler(IHttpClientFactory httpClientFactory, ILogger<CreditDataQueryHandler> logger, IConfiguration configuration)
        {
            _httpClien = httpClientFactory.CreateClient("CreditDataQuery");
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<CreditData> Handle(SSN request, CancellationToken cancellationToken)
        {
            try { 
            string url = _configuration["DevSkillUri"];
            var personalDetailsTask = GetPrsonalDetails(_httpClien, url, request.Ssn, cancellationToken);
            var assessedIncomeTask = GetAssessedIncome(_httpClien, url, request.Ssn, cancellationToken);
            var debtTask = GetDebt(_httpClien, url, request.Ssn, cancellationToken);

            await Task.WhenAll(personalDetailsTask, assessedIncomeTask, debtTask);

            var personalDetails = await personalDetailsTask;
            var assessedIncome = await assessedIncomeTask;
            var debt = await debtTask;
            return new CreditData(
                   personalDetails.first_name,
                   personalDetails.last_name,
                   personalDetails.address,
                   assessedIncome.assessed_income,
                   debt.balance_of_debt,
                   debt.complaints);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service Unavailble");
                throw new HttpRequestException();
            }
           
        }

        public async Task<PrsonalDetails> GetPrsonalDetails(HttpClient _httpClien, string url ,string ssn, CancellationToken cancellationToken)
        {
            var personalDetailsResponse = await _httpClien.GetStringAsync(url + $"personal-details/{ssn}", cancellationToken);
            var result = JsonSerializer.Deserialize<PrsonalDetails>(personalDetailsResponse);
            return result;
        }
        public async Task<Debt> GetDebt(HttpClient _httpClien, string url, string ssn, CancellationToken cancellationToken)
        {
            var personalDetailsResponse = await _httpClien.GetStringAsync(url + $"debt/{ssn}", cancellationToken);
            var result = JsonSerializer.Deserialize<Debt>(personalDetailsResponse);
            return result;
        }
        public async Task<AssessedIncome> GetAssessedIncome(HttpClient _httpClien, string url, string ssn, CancellationToken cancellationToken)
        {
            var personalDetailsResponse = await _httpClien.GetStringAsync(url + $"assessed-income/{ssn}", cancellationToken);
            var result = JsonSerializer.Deserialize<AssessedIncome>(personalDetailsResponse);
            return result;
        }
    }
}
