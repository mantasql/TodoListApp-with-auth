using TodoList_auth.Models;

namespace TodoList_auth.Repo
{
    public interface ITodoListRepository
    {
        public IQueryable<TodoList> TodoLists { get; }

        public Task<TodoList> GetById(int id);

        public Task<TodoList> AddTodoList(TodoList todoList);

        public Task<TodoList> DeleteTodoList(TodoList todoList);

        public Task<TodoList> UpdateTodoList(TodoList todoList);
    }
}
