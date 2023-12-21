
using Azure.Messaging.ServiceBus;
using Mail.Models.Dto;
using Mail.Service;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

namespace Mail.Messaging
{
   
    public class AzureBusServices : IAzureBus
    {
        private readonly IConfiguration _configuration;
        private readonly String _connectionString;
        private readonly String _queueName;
        private readonly ServiceBusProcessor _processor;
        private readonly MailsService _emailService;
        public AzureBusServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("AzureConnectionString");
            _queueName = _configuration.GetValue<string>("Queue:RegisterQueue");
           

            var client = new ServiceBusClient(_connectionString);
            _processor = client.CreateProcessor(_queueName);
            _emailService = new MailsService(configuration);
        }
        public async Task start()
        {
            _processor.ProcessMessageAsync += OnRegisterUser;
            _processor.ProcessErrorAsync += ErrorHandler;
            await _processor.StartProcessingAsync();
        }

        public async Task stop()
        {
            await _processor.StopProcessingAsync();
            await _processor.DisposeAsync();
        }

        private Task ErrorHandler(ProcessErrorEventArgs arg)
        {
            return Task.CompletedTask;
        }

        private async Task OnRegisterUser(ProcessMessageEventArgs arg)
        {
            var message = arg.Message;
            var body = Encoding.UTF8.GetString(message.Body);
            var user = JsonConvert.DeserializeObject<UserMessageDto>(body);
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                
                stringBuilder.Append("<h1> Hello " + user.Name + "</h1>");
                stringBuilder.AppendLine("<br/>Welcome to our SocialApp");

                stringBuilder.Append("<br/>");
                stringBuilder.Append('\n');
                stringBuilder.Append("<p>Start your First Adventure!!</p>");

                await _emailService.sendEmail(user, stringBuilder.ToString());



                await arg.CompleteMessageAsync(arg.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
