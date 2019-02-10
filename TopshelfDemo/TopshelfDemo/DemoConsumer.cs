using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;

namespace TopshelfDemo
{
    class DemoConsumer : IConsumer<IDemo>
    {
        public async Task Consume(ConsumeContext<IDemo> context)
        {
            await Console.Out.WriteLineAsync($"Updating customer: {context.Message.id}");
            
        }
    }
}
