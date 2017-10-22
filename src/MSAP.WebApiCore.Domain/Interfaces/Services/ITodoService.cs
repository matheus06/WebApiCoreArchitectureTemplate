using System.Collections.Generic;
using MSAP.WebApiCore.Domain.Models;

namespace MSAP.WebApiCore.Domain.Interfaces.Services
{
    public interface ITodoService : IService<Todo>
    {
      //  IEnumerable<TodoClass> GetaAllWithInclude();
    }
}