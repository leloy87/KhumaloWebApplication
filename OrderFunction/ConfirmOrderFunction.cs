using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFunction
{
    internal class ConfirmOrderFunction
    {
        public static class ConfirmOrderFunction
        {
            [FunctionName("ConfirmOrder")]
            public static async Task ConfirmOrder([ActivityTrigger] Order order, ILogger log)
            {
                // Simulate order confirmation
                log.LogInformation($"Confirming order: {order.OrderId}");
                await Task.Delay(1000); // Simulate a delay
                log.LogInformation("Order confirmed.");
            }
        }
    }
}
