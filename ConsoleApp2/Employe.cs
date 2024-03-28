using Newtonsoft.Json;

namespace ConsoleApp2;

public class Employe
{
    private  readonly List<Inventory> _inventories = new List<Inventory>();
    public Employe(string name, string jobTitle)
    {
        Name = name;
        JobTitle = jobTitle;

    }

    public  string Name { get; private set; }
    public string JobTitle { get; private set; }
    
    public IReadOnlyList<Inventory> GetInventory()
    {
        return _inventories;
    }

 
    public void PrintInventory()
    {
        Console.WriteLine($"Список предметов сотрудника {Name} ");
        foreach (var inventory in _inventories)
        {
            Console.WriteLine($"У сотрудника {Name} имеются предметы:\n" +
                              $"ID:{inventory.Number},{inventory.NameInventory}");
        }
    }

    public  Inventory FindInventory(string name)
    {
        foreach (var inventory in _inventories)
        {
            if (inventory.NameInventory == name)
            {
                return inventory;
            }
        }
        Console.WriteLine("Такого предмета в списке нет.");
        return null;
    }

    public void RemoveInventory(Inventory inventory)
    {
        _inventories.Remove(inventory);
    }


    public void AddInventory(Inventory inventory)
    {
        _inventories.Add(inventory);
      
    }

}