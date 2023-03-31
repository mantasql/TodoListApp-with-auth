using Microsoft.EntityFrameworkCore;
using TodoList_auth.DataAccess;
using TodoList_auth.Models;

namespace TodoList_auth.Repo
{
    public class EFTodoListRepository : ITodoListRepository
    {
        private readonly TodoListContext _context;

        public EFTodoListRepository(TodoListContext context)
        {
            this._context = context;
        }

        public IQueryable<TodoList> TodoLists => _context.TodoLists;

        public async Task<TodoList> AddTodoList(TodoList todoList)
        {
            var result = await _context.TodoLists.AddAsync(todoList);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TodoList> DeleteTodoList(TodoList todoList)
        {
            _context.TodoLists.Remove(todoList);
            await _context.SaveChangesAsync();

            return todoList;
        }

        public async Task<TodoList> GetById(int id)
        {
            return await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TodoList> UpdateTodoList(TodoList todoList)
        {
            TodoList result = await _context.TodoLists.FirstOrDefaultAsync(t => t.Id == todoList.Id) ?? throw new ArgumentException("TodoList not found", nameof(todoList));
            todoList.CreatedDate = result.CreatedDate;
            todoList.UserId = result.UserId;
            todoList.TodoEntries = result.TodoEntries;

            _context.ChangeTracker.Clear();
            _context.Update(todoList);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
