using Mail.Messaging;
using System.Runtime.CompilerServices;

namespace Mail.Extensions
{
    public static class AzureServiceBusExtension
    {
        public static IAzureBus azureBus { get; set; }
        public static IApplicationBuilder useAzure(this IApplicationBuilder app)
        {
            azureBus = app.ApplicationServices.GetService<IAzureBus>();
             var HostLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            HostLifetime.ApplicationStarted.Register(OnAppStart);
            HostLifetime.ApplicationStopping.Register(OnAppStopping);
            return app;
        }

        private static void OnAppStopping()
        {
            azureBus.stop();
        }

        private static void OnAppStart()
        {
            azureBus.start();
        }
    }
}
