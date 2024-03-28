namespace ConsoleApp2;

public class Furniture:Inventory
{
    public string Color { get; private set; }
    public Furniture(string nameInventory,string color) : base(nameInventory)
    {
        Color = color;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"{Color}");
    }
    
}