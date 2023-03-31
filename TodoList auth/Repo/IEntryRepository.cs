using TodoList_auth.Models;

namespace TodoList_auth.Repo
{
    public interface IEntryRepository
    {
        public IQueryable<TodoEntry> TodoEntries { get; }

        public Task<TodoEntry> GetById(int id);

        public Task<TodoEntry> AddEntry(TodoList todoList);

        public Task<TodoEntry> DeleteEntry(TodoList todoList);

        public Task<TodoEntry> UpdateEntry(TodoList todoList);
    }
}
