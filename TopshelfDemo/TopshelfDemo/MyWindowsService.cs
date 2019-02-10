using MassTransit;
using System;

namespace TopshelfDemo
{
    class MyWindowsService
    {
        IBusControl _bus;

        public void Start()
        {
            _bus = ConfigureBus();
            _bus.Start();

        }

        public void Stop()
        {
            _bus?.Stop(TimeSpan.FromSeconds(30));
        }

        IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "event_queue", e =>
                {
                    e.Consumer<DemoConsumer>();
                });

            });
        }
    }
}
