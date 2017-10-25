using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Events;

namespace MSAP.WebApiCore.Services.SubscribeApi.IntegrationEvents.Events
{
    public class TodoModelChangedIntegrationEvent : IntegrationEvent
    {
        public int ModelId { get; private set; }

        public decimal NewValue { get; private set; }

        public decimal OldValue { get; private set; }

        public TodoModelChangedIntegrationEvent(int modelId, decimal newValue, decimal oldValue)
        {
            ModelId = modelId;
            NewValue = newValue;
            OldValue = oldValue;
        }
    }
}
