using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialMessageBus
{
    public class MessageBusServices : IMessageBus
    {
        private readonly string connectionString = "Endpoint=sb://socialbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=IYHN5lI6/vS9BFg6TGbT2ejCC88USA6Fp+ASbCGSaMo=";
        public async Task PublishMessage(object message, string Topic_Queue_Name)
        {
            var client = new ServiceBusClient( connectionString);
            ServiceBusSender sender = client.CreateSender(Topic_Queue_Name);


            var body = JsonConvert.SerializeObject(message);
            ServiceBusMessage busMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(body))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };
            await sender.SendMessageAsync(busMessage);
            await sender.DisposeAsync();

        }
    }
}
