using System.Collections.Generic;
using MSAP.WebApiCore.Domain.Models;

namespace MSAP.WebApiCore.Domain.Interfaces.Repositories
{
    public interface ITodoRepository : IRepository<Todo>
    {
       // IEnumerable<TodoClass> GetaAllWithInclude();
    }
}