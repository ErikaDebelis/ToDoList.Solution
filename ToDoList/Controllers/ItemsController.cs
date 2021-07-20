using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
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
      return RedirectToAction("Index");
      //The route decorator "/items" matches our form's action. When a form is submitted, this route will be invoked. The route method takes a single string parameter named description. This matches the name attribute of our form's single field.
      //While we could add List<Item> allItems = Item.GetAll(); to our Create() method, it wouldn't be very DRY.

//Instead, we can use a method called RedirectToAction() to redirect to another route. RedirectToAction() takes a route method as an argument. RedirectToAction("Index"); tells the server to invoke the Index() route after the Create() route has been invoked. This means we don't have to repeat the code in Index(). We can just tell Create() to redirect to Index() instead.
    }

  }
}