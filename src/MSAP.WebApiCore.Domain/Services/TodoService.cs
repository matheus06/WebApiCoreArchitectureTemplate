using MSAP.WebApiCore.Domain.Interfaces.Repositories;
using MSAP.WebApiCore.Domain.Interfaces.Services;
using MSAP.WebApiCore.Domain.Models;

namespace MSAP.WebApiCore.Domain.Services
{
    public class TodoService : Service<Todo>, ITodoService
    {
        public TodoService(IRepository<Todo> repository) : base(repository)
        {
        }
    }
}