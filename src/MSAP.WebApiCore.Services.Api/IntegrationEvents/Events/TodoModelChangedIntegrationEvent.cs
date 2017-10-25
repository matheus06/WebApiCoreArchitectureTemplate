using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Events;

namespace MSAP.WebApiCore.Services.Api.IntegrationEvents.Events
{
    public class TodoModelChangedIntegrationEvent : IntegrationEvent
    {
        public string ModelId { get; private set; }

        public string NewValue { get; private set; }

        public string OldValue { get; private set; }

        public TodoModelChangedIntegrationEvent(string modelId, string newValue, string oldValue)
        {
            ModelId = modelId;
            NewValue = newValue;
            OldValue = oldValue;
        }
    }
}
