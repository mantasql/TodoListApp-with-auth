using TodoList_auth.DataAccess;
using TodoList_auth.Models;

namespace TodoList_auth.Repo
{
    public class EFEntryRepository : IEntryRepository
    {
        private readonly TodoListContext _context;

        public IQueryable<TodoEntry> TodoEntries => _context.TodoEnties;

        public Task<TodoEntry> AddEntry(TodoList todoList)
        {
            throw new NotImplementedException();
        }

        public Task<TodoEntry> DeleteEntry(TodoList todoList)
        {
            throw new NotImplementedException();
        }

        public Task<TodoEntry> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoEntry> UpdateEntry(TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}
