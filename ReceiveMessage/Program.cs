using MassTransit;
using System;

namespace ReceiveMessage
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

                sbc.ReceiveEndpoint(host, "new_queue", ep =>
                  {
                      ep.Consumer<MessageConsumer>();
                  });
            });
            bus.Start();
            Console.WriteLine("Any Key to Exit!");
            Console.ReadKey();
            bus.Stop();
        }
    }
}
