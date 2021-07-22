using System.Collections.Generic;

namespace ToDoList.Models
{
public class Item
{
  public string Description { get; set; }
  public int Id { get; } //updating our Item class to contain a new Id property. We don't add a set method, because this property will be set in the constructor automatically. In fact, we specifically don't ever want to manually edit it. That would increase the risk of IDs not being unique.
  private static List<Item> _instances = new List<Item> {};


    public Item(string description)
    {
      Description = description;
      _instances.Add(this); //we use this to reference the Item being actively constructed by the constructor
      Id = _instances.Count; //Then we'll set this property in the constructor

    }
    public static Item Find(int searchId)
    {
      return _instances[searchId-1]; //notice we subtract 1 from the provided searchId because indexes in the _instances array begin at 0, whereas our Id properties will begin at 1.
    }


    public static List<Item> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

  }
}