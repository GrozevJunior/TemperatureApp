using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using System.Text;
using TemperatureApp.Handler;
using TemperatureApp.Logger;
using TemperatureApp.Model;
using TemperatureApp.Parser;

namespace TemperatureApp
{
    internal class TemperatureClientApp
    {
        private const string Ip = "162.55.32.224";
        private const int Port = 5693;
        private const string User = "DemoUser2023";
        private const string Password = "cWwsSv3zP73y";
        private const string Topic = "ondo/measuring_box";

        private static ILogger logger = new ConsoleLogger();
        private static TemperatureModelParser parser = new TemperatureModelParser();
        private static TemperatureHandler handler = new TemperatureHandler();
        public static async Task Main(string[] args)
        {
            var options = new MqttClientOptionsBuilder()
                                        .WithTcpServer(Ip, Port)
                                        .WithCredentials(User, Password)
                                        .Build();
  
            IMqttClient mqttClient= new MqttFactory().CreateMqttClient();

            mqttClient.UseConnectedHandler(async e =>
            {
                logger.Log("Connected to the broker!");
                var topicFilter = new TopicFilterBuilder()
                                        .WithTopic(Topic)
                                        .Build();
                await mqttClient.SubscribeAsync(topicFilter);
            });

            mqttClient.UseDisconnectedHandler(e =>
            {
                logger.Log("Disconnected from the broker!");

            });


            mqttClient.UseApplicationMessageReceivedHandler(HandleTemperatureEvent);

            await mqttClient.ConnectAsync(options);

            logger.Log("Press any key to end process.");
            Console.ReadLine();
            await mqttClient.DisconnectAsync();
        }

        private static void HandleTemperatureEvent(MqttApplicationMessageReceivedEventArgs e)
        {
            TemperatureModel temperatureModel = parser.ParseInput(e.ApplicationMessage.Payload);
            handler.Handle(temperatureModel);
        }
        
        
    }
}
