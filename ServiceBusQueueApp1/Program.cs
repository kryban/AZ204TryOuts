using System;
using System.Text;
using Microsoft.Azure.ServiceBus;

namespace ServiceBusQueueSENDERApp1
{
    class Program
    {
        // az servicebus namespace create -n bansasb002 -g vs-bandik-we --sku basic
        // az servicebus queue create --name bansasbqueue002 --namespace-name bansasb002 -g vs-bandik-we --max-size 1024 --max-delivery-count 5 --enable-dead-lettering-on-message-expiration true
        // az servicebus namespace authorization-rule create -n bansListener001 --namespace-name bansasb002 -g vs-bandik-we --rights Listen
        // az servicebus namespace authorization-rule create -n bansSender001 --namespace-name bansasb002 -g vs-bandik-we --rights Send
        // az servicebus namespace authorization-rule keys list --namespace-name bansasb002 -g vs-bandik-we -n bansSender001
        // az servicebus namespace authorization-rule keys list --namespace-name bansasb002 -g vs-bandik-we -n bansListener001

        static void Main(string[] args)
        {
            string connstr = "Endpoint=sb://bansasb002.servicebus.windows.net/;SharedAccessKeyName=bansSender001;SharedAccessKey=k13PH3AkG0cYkoN6S5Sw66eu2l6QNDzmunqXZuYxi2Q=";
            string queueName = "bansasbqueue002";

            IQueueClient client = new QueueClient(connstr, queueName);

            bool nogEenKeer = true;

            while (nogEenKeer)
            {
                byte[] fooMessageBody = Encoding.UTF8.GetBytes($"This is sent from code with timestamp {DateTime.Now:fffffff}");
                Message message = new Message(fooMessageBody);
                message.MessageId = Guid.NewGuid().ToString();
                message.UserProperties.Add("Afzender", "ban");

                client.SendAsync(message).Wait();
                Console.WriteLine($"Message Sent to queue: {client.Path} on Service Bus({client.ServiceBusConnection.Endpoint}).");

                Console.WriteLine("Nog een keer ? (Y)es (N)o");
                var inp = Console.ReadLine();

                nogEenKeer = (inp == "Y" || inp == "y");
            }
        }
    }
}
