using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFunction
{
    public static class OrderOrchestrator
    {
        [FunctionName("OrderOrchestrator")]
        public static async Task RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var order = context.GetInput<Order>();

            // Update Inventory
            await context.CallActivityAsync("UpdateInventory", order);

            // Process Payment
            await context.CallActivityAsync("ProcessPayment", order);

            // Confirm Order
            await context.CallActivityAsync("ConfirmOrder", order);

            // Send Notifications
            await context.CallActivityAsync("SendNotification", order);
        }

        [FunctionName("OrderOrchestrator_HttpStart")]
        public static async Task<IActionResult> HttpStart(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JObject.Parse(requestBody);
            var order = data.ToObject<Order>();

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("OrderOrchestrator", order);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }

    public class Order
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerEmail { get; set; }
    }
