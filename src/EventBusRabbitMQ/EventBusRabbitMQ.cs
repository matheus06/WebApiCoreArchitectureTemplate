using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Events;
using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventBusRabbitMQ
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        private readonly string BROKER_NAME = "wepapicore_event_bus";
        private readonly Dictionary<string, List<IIntegrationEventHandler>> _handlers;
        private readonly List<Type> _eventTypes;
        private string _queueName;

        public EventBusRabbitMQ()
        {
            _handlers = new Dictionary<string, List<IIntegrationEventHandler>>();
            _eventTypes = new List<Type>();
        }

        public void Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;
            var factory =
                new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: BROKER_NAME,
                    type: "direct");
                string message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: BROKER_NAME,
                    routingKey: eventName,
                    basicProperties: null,
                    body: body);
            }
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            var eventName = typeof(T).Name;
            var factory =
                new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                _queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: _queueName,
                    exchange: BROKER_NAME,
                    routingKey: eventName);
                _handlers.Add(eventName, new List<IIntegrationEventHandler>());
                _handlers[eventName].Add(handler);
                _eventTypes.Add(typeof(T));
            }
        }
        
        public void Unsubscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            var eventName = typeof(T).Name;
            if (_handlers.ContainsKey(eventName) && _handlers[eventName].Contains(handler))
            {
                _handlers[eventName].Remove(handler);

                if (_handlers[eventName].Count == 0)
                {
                    _handlers.Remove(eventName);
                    var eventType = _eventTypes.Single(e => e.Name == eventName);
                    _eventTypes.Remove(eventType);
                    var factory = new ConnectionFactory() { HostName = "localhost"};
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        _queueName = channel.QueueDeclare().QueueName;
                        channel.QueueBind(queue: _queueName,
                            exchange: BROKER_NAME,
                            routingKey: eventName);
                    }

                    if (_handlers.Keys.Count == 0)
                    {
                        _queueName = string.Empty;
                    }

                }
            }
        }

        public void Dispose()
        {
            _handlers.Clear();
        }
    }
}
