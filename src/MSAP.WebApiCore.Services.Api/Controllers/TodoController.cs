using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSAP.WebApiCore.Application.Interfaces;
using MSAP.WebApiCore.Application.ViewModels;
using MSAP.WebApiCore.Domain.Models;
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
        private readonly IMapper _mapper;

        public TodoController(IAppTodoService todoAppService, IEventBus eventBus, IMapper mapper)
        {
            _todoAppService = todoAppService;
            _eventBus = eventBus;
            _mapper = mapper;
        }

        // GET: api/Todo
        [HttpGet]
        public IEnumerable<TodoViewModel> ObterTodos()
        {
            return _todoAppService.ObterTodos();
        }


        [HttpPost]
        public IActionResult Create([FromBody] Todo item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _todoAppService.Adicionar(_mapper.Map<TodoViewModel>(item));
            var @event = new TodoModelChangedIntegrationEvent(item.Descricao, item.Host, item.Serial);
            _eventBus.Publish(@event);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

    }
}