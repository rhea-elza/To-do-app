using Microsoft.AspNetCore.Mvc;
using todo.Models;

namespace todo.Controllers
{
    public interface ITodoController
    {
        IActionResult Delete(int? id);
        IActionResult Index();
        IActionResult Index(Todo obj);
        IActionResult List();
    }
}