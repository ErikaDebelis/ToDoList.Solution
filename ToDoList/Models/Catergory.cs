using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Item> Items { get; set; } //Items will contain a List of all Item objects that belong to that Category. For instance, if we had a Category with a Name of "chores," this list would contain a series of Item objects with Descriptions like "mop the floor", "scrub the shower", or "do the dishes."
    public Category(string categoryName)
    {
      Name = categoryName;
      _instances.Add(this); //We add each Category to the static _instances list in the constructor when it's created.
      Id = _instances.Count; //We assign an Id number equal to the number of Categorys in _instances.
      Items = new List<Item>{}; //We create a new empty List to eventually contain Item objects that belong to this Category.
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Category> GetAll()
    {
      return _instances;
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}