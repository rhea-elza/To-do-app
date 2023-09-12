using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo.Models;
using todo.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _db;
        public TodoController(AppDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Todo obj)
        {
            _db.Todo.Add(obj);//Keeps track of all the changes you need to do in the db
            _db.SaveChanges();//go to database and create that category
            return View();
        }
        public IActionResult List()
        {
            List<Todo> objTodoList = _db.Todo.ToList();
            return View(objTodoList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Todo? todoFromDb = _db.Todo.Find(id);
            if (todoFromDb == null)
            {
                return NotFound();
            }
            
            _db.Todo.Remove(todoFromDb);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        //[HttpPost]
        //public IActionResult Delete(Todo obj)
        //{
        //    _db.Todo.Add(obj);//Keeps track of all the changes you need to do in the db
        //    _db.SaveChanges();//go to database and create that category
        //    return RedirectToAction("List");
        //}
        //[HttpPost]
        //public IActionResult Delete(int? id)
        //{
        //    Todo? obj = _db.Todo.Find(id);
        //    _db.Todo.Remove(obj);
        //    return RedirectToAction("List");
        //}

    }
}

