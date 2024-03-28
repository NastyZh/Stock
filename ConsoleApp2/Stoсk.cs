namespace ConsoleApp2;

using System.Collections.Generic;

public class Stoсk
{
    public   List<Inventory> _inventories { get; set; }= new List<Inventory>();


    public void AddInventory(Inventory inventory)
    {
       _inventories.Add(inventory);
       JsonHandler.SerialaseObject(_inventories);
    }

    public void AddRangeInventories(IReadOnlyList<Inventory> inventories)
    {
        _inventories.AddRange(inventories);
    }

    public void PrintInventories()
    {
        foreach (var inventory in _inventories)
        {
            Console.WriteLine($"{inventory.NameInventory}");
        }
    }

    public Inventory FindInventory(string name)
    {
        foreach (var inventory in _inventories)
        {
            if (inventory.NameInventory == name)
            {
                return inventory;
            }
        }

        return null;
    }

    public void RemoveInventory(Inventory inventory)
    {
        for (int i = _inventories.Count - 1; i >= 0; i--)
        {
            if (_inventories[i] == inventory)
            {
                _inventories.RemoveAt(i);
            }
        }
    }

  
}