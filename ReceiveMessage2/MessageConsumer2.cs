using MassTransit;
using Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReceiveMessage
{
    public class MessageConsumer2 : IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            await Console.Out.WriteLineAsync($"Received Second Message: {context.Message.Name}");
        }
    }
}
