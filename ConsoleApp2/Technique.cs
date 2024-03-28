namespace ConsoleApp2;

public class Technique:Inventory
{
    public string Model { get; private set; }
    public Technique(string nameInventory,string model ) : base(nameInventory )
    {
        Model = model;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"{Model}, ");
    }
}