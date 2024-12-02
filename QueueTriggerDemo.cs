using System;
using Azure.Storage.Queues.Models;
using Google.Protobuf;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace azfuncdemocode
{
    public class QueueTriggerDemo
    {
        private readonly ILogger<QueueTriggerDemo> _logger;

        public QueueTriggerDemo(ILogger<QueueTriggerDemo> logger)
        {
            _logger = logger;
        }

        [Function(nameof(QueueTriggerDemo))]
        [QueueOutput("output-queue",Connection = "queueConnection")]
        public QueueData Run([QueueTrigger("input-queue", Connection = "queueConnection")] QueueData message)
        {

            _logger.LogInformation($"C# Queue trigger function processed: {message.Name} \n  {message.Description}");

            return message;
        }
    }
    public class QueueData
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}