using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFunction
{
    internal class ProcessPaymentFunction
    {
        public static class ProcessPaymentFunction
        {
            [FunctionName("ProcessPayment")]
            public static async Task ProcessPayment([ActivityTrigger] Order order, ILogger log)
            {
                // Simulate payment processing
                log.LogInformation($"Processing payment for OrderId: {order.OrderId}");
                await Task.Delay(1000); // Simulate a delay
                log.LogInformation("Payment processed.");
            }
        }
    }
}
