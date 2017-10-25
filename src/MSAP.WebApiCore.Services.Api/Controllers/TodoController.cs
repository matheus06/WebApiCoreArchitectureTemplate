using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSAP.WebApiCore.Application.Interfaces;
using MSAP.WebApiCore.Application.ViewModels;

namespace MSAP.WebApiCore.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        private readonly IAppTodoService _todoAppService;

        public TodoController(IAppTodoService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        // GET: api/Todo
        [HttpGet]
        public IEnumerable<TodoViewModel> ObterTodos()
        {
            return _todoAppService.ObterTodos();
        }

    }
}