using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MSAP.WebApiCore.Domain.Interfaces.Repositories;
using MSAP.WebApiCore.Domain.Models;
using MSAP.WebApiCore.Infra.Data.Context;

namespace MSAP.WebApiCore.Infra.Data.Repositories
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        private readonly WebApiContext _context;
        public TodoRepository(WebApiContext context) : base(context)
        {
            _context = context;
        }

        //public IEnumerable<TodoClass> GetaAllWithInclude()
        //{
        //   return _context.TodoClass.Include(e => e.OtherClass);
        //}
    }
}