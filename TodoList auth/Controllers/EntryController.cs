using Microsoft.AspNetCore.Mvc;
using TodoList_auth.Repo;

namespace TodoList_auth.Controllers
{
    public class EntryController : Controller
    {
        private readonly IEntryRepository _repository;

        public IActionResult Index([FromRoute] int id)
        {
            return View(_repository.TodoEntries.Where(x => x.TodoListId == id));
        }
    }
}
