using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Events;

namespace MSAP.WebApiCore.Infra.CrossCutting.EventBus.Interfaces
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);
        void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent;

        void Unsubscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent;
    }
}
