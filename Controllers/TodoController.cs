using Microsoft.AspNetCore.Mvc;
using BaiTuan3.Models;

namespace BaiTuan3.Controllers
{
    public class TodoController : Controller
    {
        private static List<Todo> _todos = new List<Todo>
        {
            new Todo { Id = 1, Title = "Đi chợ", IsCompleted = true },
            new Todo { Id = 2, Title = "Chơi thể thao", IsCompleted = false },
            new Todo { Id = 3, Title = "Chơi game", IsCompleted = false },
            new Todo { Id = 4, Title = "Học bài", IsCompleted = true }
        };

        public IActionResult Index()
        {
            return View(_todos);
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                todo.Id = _todos.Count > 0 ? _todos.Max(t => t.Id) + 1 : 1;
                _todos.Add(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Edit(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            var existing = _todos.FirstOrDefault(t => t.Id == todo.Id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.Title = todo.Title;
                existing.IsCompleted = todo.IsCompleted;
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

