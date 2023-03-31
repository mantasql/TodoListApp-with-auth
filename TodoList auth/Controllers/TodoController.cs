using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TodoList_auth.Models;
using TodoList_auth.Repo;

namespace TodoList_auth.Controllers
{
    [Authorize]
    [Controller]
    public class TodoController : Controller
    {
        private readonly ITodoListRepository _repository;

        public TodoController(ITodoListRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: TodoController
        public ActionResult TodoLists()
        {
            string userId = User.Identity.Name;

            return View(_repository.TodoLists.Where(u => u.UserId == userId));
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoList todoList)
        {
            todoList.CreatedDate = DateTime.Now;
            todoList.UserId = User.Identity.Name;

            try
            {
                await _repository.AddTodoList(todoList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

            return RedirectToAction(nameof(TodoLists));
        }

        // GET: TodoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var todoList = await _repository.GetById(id);

                if (todoList is null)
                {
                    NotFound();
                }

                return View(todoList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoList todoList)
        {
            try
            {
                await _repository.UpdateTodoList(todoList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

            return RedirectToAction(nameof(TodoLists));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var todoList = await _repository.GetById(id);

                if (todoList is null)
                {
                    NotFound();
                }

                return View(todoList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TodoList todoList)
        {
            try
            {
                await _repository.DeleteTodoList(todoList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

            return RedirectToAction(nameof(TodoLists));
        }
    }
}
