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
    public class TodoController : Controller, ITodoController
    {
        private readonly IAppDbContext _db;

        public TodoController(IAppDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo obj)
        {
            _db.Todo.Add(obj);//Keeps track of all the changes you need to do in the db
            _db.SaveChanges();//go to database and create that category
            return RedirectToAction("Index");
        }

        public IActionResult Index()
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
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
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

            return View(todoFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Todo obj)
        {
            _db.Todo.Update(obj);//Keeps track of all the changes you need to do in the db
            _db.SaveChanges();//go to database and create that category
            return RedirectToAction("Index");
        }



    }
}