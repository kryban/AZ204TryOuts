using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace ServiceBusTopicRECEIVERApp001
{
    class Program
    {
        // See ServiceBusQueueSENDERApp1 for az commands for creating service bus, queue and policies
        // subscription must be created first

        // az servicebus topic subscription create -n bansSub001 --namespace-name bansasb002 -g vs-bandik-we --topic-name bansasbtopic002
        static ISubscriptionClient subClient;

        static void Main(string[] args)
        {
          //string connstr = "Endpoint=sb://bansasb002.servicebus.windows.net/;SharedAccessKeyName=bansListener001;SharedAccessKey=TWEriENVjuVvrW2RHQulpups28vWU/EkrW6yvZ0Hulk=";
            string connstr = "Endpoint=sb://bansasb002.servicebus.windows.net/;SharedAccessKeyName=tst;SharedAccessKey=NC2t4Z5QpCSdam9P+zPqmrPaH7RlkkPpAqcMGbU869o=;EntityPath=bansasbtopic002";
            string topicName = "bansasbtopic002";

            string subscriptionName = "bansSub001";

            ServiceBusConnectionStringBuilder connectionBuilder = new ServiceBusConnectionStringBuilder(connstr);
            //connectionBuilder.EntityPath = topicName;

            subClient = new SubscriptionClient(connectionBuilder, subscriptionName);

            var handlerOptions = new MessageHandlerOptions(ExceptionReceived)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            subClient.RegisterMessageHandler(Afhandelaar, handlerOptions);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static async Task Afhandelaar(Message _message, CancellationToken _token)
        {
            string kenmerk = _message.UserProperties["Kenmerk"].ToString();
            
            Console.WriteLine("This is subscriber 1, without filters");
            Console.WriteLine("\n----------------");
            Console.WriteLine($"{Encoding.UTF8.GetString(_message.Body)}");
            Console.WriteLine($"Kenmerk => {kenmerk}");
            Console.WriteLine("----------------\n");

            subClient.CompleteAsync(_message.SystemProperties.LockToken);
        }

        static Task ExceptionReceived(ExceptionReceivedEventArgs args)
        {
            Console.WriteLine(args.Exception);
            return Task.CompletedTask;
        }
    }
}
