using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MSAP.WebApiCore.Application.Interfaces;
using MSAP.WebApiCore.Application.ViewModels;
using MSAP.WebApiCore.Domain.Interfaces.Repositories;
using MSAP.WebApiCore.Domain.Interfaces.Services;
using MSAP.WebApiCore.Domain.Models;

namespace MSAP.WebApiCore.Application.AppService
{
    public class AppTodoService : IAppTodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;
        public AppTodoService(ITodoService todoService, IMapper mapper, ITodoRepository todoRepository)
        {
            _todoService = todoService;
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public void Adicionar(TodoViewModel equipeViewModel)
        {
            var todo = _mapper.Map<TodoViewModel, Todo>(equipeViewModel);
             _todoService.Add(todo);
        }

        public Task AdicionarAsync(TodoViewModel equipeViewModel)
        {
            var todo = _mapper.Map<TodoViewModel, Todo>(equipeViewModel);
           return _todoService.AddAsync(todo);
        }

        public TodoViewModel ObterPorId(int id)
        {
            return _mapper.Map<TodoViewModel>(_todoService.GetById(id));
        }

        public IEnumerable<TodoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TodoViewModel>>(_todoRepository.GetAll());
        }

        public void Atualizar(TodoViewModel todoViewModel)
        {
            var todo = _mapper.Map<TodoViewModel, Todo>(todoViewModel);
            _todoService.Update(todo);
        }

        public void Remover(int id)
        {
            _todoService.Remove(id);
        }

        //public IEnumerable<TodoViewModel> ObterTodosInclude()
        //{
        //    return _mapper.Map<IEnumerable<TodoViewModel>>(_todoRepository.GetaAllWithInclude());
        //}


        public void Dispose()
        {

        }

    }
}
