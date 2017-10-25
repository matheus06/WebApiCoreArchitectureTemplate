using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MSAP.WebApiCore.Application.ViewModels;

namespace MSAP.WebApiCore.Application.Interfaces
{
    public interface IAppTodoService : IDisposable
    {
        void Adicionar(TodoViewModel todoViewModel);
        Task AdicionarAsync(TodoViewModel todoViewModel);
        TodoViewModel ObterPorId(int id);
        IEnumerable<TodoViewModel> ObterTodos();
        void Atualizar(TodoViewModel todoViewModel);
        void Remover(int id);
    }
}