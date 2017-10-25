using System;
using System.Threading.Tasks;
using MSAP.WebApiCore.Application.Interfaces;
using MSAP.WebApiCore.Application.ViewModels;
using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Interfaces;
using MSAP.WebApiCore.Services.SubscribeApi.IntegrationEvents.Events;

namespace MSAP.WebApiCore.Services.SubscribeApi.IntegrationEvents.EventHandling
{
    public class TodoModelChangedIntegrationEventHandler : IIntegrationEventHandler<TodoModelChangedIntegrationEvent>
    {
        private readonly IAppTodoService _todoAppService;
        public TodoModelChangedIntegrationEventHandler(IAppTodoService todoAppService)
        {
            _todoAppService = todoAppService;

        }

        public Task Handle(TodoModelChangedIntegrationEvent @event)
        {
            TodoViewModel todoView = new TodoViewModel();
            todoView.Descricao = "Evento Recebido";
            todoView.Serial = "Evento New Value" + @event.NewValue;
            todoView.Host = "Evento Old Value" + @event.OldValue;
           return _todoAppService.AdicionarAsync(todoView);
        }
    }
}
