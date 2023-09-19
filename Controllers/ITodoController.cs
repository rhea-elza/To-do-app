using Microsoft.AspNetCore.Mvc;
using todo.Models;

namespace todo.Controllers
{
    public interface ITodoController
    {
        IActionResult Create();
        IActionResult Create(Todo obj);
        IActionResult Delete(int? id);
        IActionResult Edit(int? id);
        IActionResult Edit(Todo obj);
        IActionResult Index();
    }
}