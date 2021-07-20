using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      Item starterItem = new Item("Add first item to To Do List");
      return View(starterItem);
    }

    [HttpGet("/items/new")]
    public ActionResult CreateForm()
    {
      return View();
      // The route simply returns View(). Because our form resides in a file called CreateForm.cshtml, the CreateForm() route method will automatically render this view.
    }
    [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);
      return View("Index", myItem);
      //The route decorator "/items" matches our form's action. When a form is submitted, this route will be invoked. The route method takes a single string parameter named description. This matches the name attribute of our form's single field.
    }

  }
}