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

            await bus.Publish(new Message(1, "Hello Tigger !!", DateTime.Now));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
