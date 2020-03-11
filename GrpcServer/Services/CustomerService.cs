using Grpc.Core;
using GrpcServer.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();

            if (request.UserId == 1)
            {
                output.Firstname = "Max";
                output.LastName = "Mustermann";
            }
            else if (request.UserId == 2)
            {
                output.Firstname = "Harald";
                output.LastName = "Schmitt";
            }
            else if (request.UserId == 3)
            {
                output.Firstname = "Karl";
                output.LastName = "Gustav";
            }


            return Task.FromResult(output);
        }

        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    Firstname = "Kevin",
                    LastName = "Winter",
                    EmailAddress = "KevinW@ppedv.de",
                    Age = 36,
                    IsAlive = false
                },
                new CustomerModel
                {
                    Firstname = "Maxi",
                    LastName = "Musterli",
                    EmailAddress = "maxm@ppedv.de",
                    Age = 34,
                    IsAlive = false
                },
                 new CustomerModel
                {
                    Firstname = "Tina",
                    LastName = "Muster",
                    EmailAddress = "Tinam@ppedv.de",
                    Age = 33,
                    IsAlive = false
                }
            };

            foreach (var cust in customers)
            {
                await responseStream.WriteAsync(cust);
            }
        }

    }
}
