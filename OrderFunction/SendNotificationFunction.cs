using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFunction
{
    internal class SendNotificationFunction
    {
        public static class SendNotificationFunction
        {
            [FunctionName("SendNotification")]
            public static async Task SendNotification([ActivityTrigger] Order order, ILogger log)
            {
                // Simulate sending notification
                log.LogInformation($"Sending notification for OrderId: {order.OrderId} to {order.CustomerEmail}");
                await Task.Delay(1000); // Simulate a delay
                log.LogInformation("Notification sent.");
            }
        }
    }
}
