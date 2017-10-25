using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSAP.WebApiCore.Application.Interfaces;
using MSAP.WebApiCore.Application.ViewModels;
using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Interfaces;
using MSAP.WebApiCore.Services.Api.IntegrationEvents.Events;

namespace MSAP.WebApiCore.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        private readonly IAppTodoService _todoAppService;
        private readonly IEventBus _eventBus;

        public TodoController(IAppTodoService todoAppService, IEventBus eventBus)
        {
            _todoAppService = todoAppService;
            _eventBus = eventBus;
        }

        // GET: api/Todo
        [HttpGet]
        public IEnumerable<TodoViewModel> ObterTodos()
        {
            var @event = new TodoModelChangedIntegrationEvent(1,2,3);
            _eventBus.Publish(@event);
            return _todoAppService.ObterTodos();
        }

    }
}