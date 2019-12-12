using MassTransit;
using ReceiveMessage;
using System;

namespace ReceiveMessage2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "new_queue_2", ep =>
                {
                    ep.Consumer<MessageConsumer2>();
                });
            });
            bus.Start();
            Console.WriteLine("Any Key to Exit!");
            Console.ReadKey();
            bus.Stop();
        }
    }
}
