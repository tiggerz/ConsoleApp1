using System;
using MassTransit;
using Messages;

namespace SendMessage
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"),h => 
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
            bus.Start();

            //await bus.Publish(new Message(1, "I'll be in touch !!", DateTime.Now));
            
            var sendEndpoint = await bus.GetSendEndpoint(new Uri("rabbitmq://localhost/new_queue"));
            await sendEndpoint.Send(new Message(1, "Private Message to new_queue Only", DateTime.Now));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
