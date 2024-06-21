using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFunction
{
    internal class UpdateInventoryFunction
    {
        public static class UpdateInventoryFunction
        {
            [FunctionName("UpdateInventory")]
            public static async Task UpdateInventory([ActivityTrigger] Order order, ILogger log)
            {
                // Simulate inventory update
                log.LogInformation($"Updating inventory for ProductId: {order.ProductId}, Quantity: {order.Quantity}");
                await Task.Delay(1000); // Simulate a delay
                log.LogInformation("Inventory updated.");
            }
        }
    }
}
