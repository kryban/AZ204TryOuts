using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace ServiceBusQueueRECEIVERApp1
{
    class Program
    {
        // See ServiceBusQueueSENDERApp1 for az commands for creating service bus, queue and policies
        static IQueueClient queueClient; 

        static void Main(string[] args)
        {
            string connstr = "Endpoint=sb://bansasb002.servicebus.windows.net/;SharedAccessKeyName=bansListener001;SharedAccessKey=TWEriENVjuVvrW2RHQulpups28vWU/EkrW6yvZ0Hulk=";
            string queueName = "bansasbqueue002";

            queueClient = new QueueClient(connstr, queueName);

            var handlerOptions = new MessageHandlerOptions(ExceptionReceived)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            queueClient.RegisterMessageHandler(Afhandelaar, handlerOptions);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static async Task Afhandelaar(Message _message, CancellationToken _token)
        {
            Console.WriteLine("\n----------------");
            Console.WriteLine($"{Encoding.UTF8.GetString(_message.Body)}");
            Console.WriteLine("----------------\n");

            queueClient.CompleteAsync(_message.SystemProperties.LockToken);
        }

        static Task ExceptionReceived(ExceptionReceivedEventArgs args)
        {
            Console.WriteLine(args.Exception);
            return Task.CompletedTask;
        }
    }
}
