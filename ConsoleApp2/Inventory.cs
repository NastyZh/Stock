namespace ConsoleApp2;

public  class Inventory
{
    public Inventory(string nameInventory)
    {
        NameInventory = nameInventory;
        
    }

    public string NameInventory { get; init; }
    
    public int Number { get; private set; }
    
    public virtual void Print()
    {
        Console.WriteLine($"{NameInventory}, {Number}.");
    }


}