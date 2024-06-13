using BookAddict.Application.Queries.OrderQueries;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Handlers.OrderHandlers
{
    public class RedirectOrderCreditCardPaymentHandler : IRequestHandler<RedirectOrderCreditCardPaymentRequest, string>
    {
        private readonly IConfiguration _configuration;

        public RedirectOrderCreditCardPaymentHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> Handle(RedirectOrderCreditCardPaymentRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult( _configuration.GetSection("FrontEndURL").Get<string>());
        }
    }
}
