using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Events;
using System.Threading.Tasks;

namespace MSAP.WebApiCore.Infra.CrossCutting.EventBus.Interfaces
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}
