namespace ConsoleApp2;

public class Company
{
    public event Action<string> EmployeeRemoved;
    public  List<Employe> Employees { get; init; } = new List<Employe>();
    public readonly Stoсk _stoсk = new Stoсk();
    public void AddEmployee(string name, string jobTitle)
    {
        Employees.Add(new Employe(name, jobTitle));
    }

    public void RemoveEmployee(Employe employe)
    {
        Employees.Remove(employe);
        var personInventory = employe.GetInventory();
        _stoсk.AddRangeInventories(personInventory);
        EmployeeRemoved?.Invoke(employe.Name);
    }

    public Employe? FindEmploye(string name)
    {
        foreach (var employe in Employees)
        {
            if (employe.Name == name)
            {
                return employe;
            }
        }

        Console.WriteLine("Такого сотрудника нет в списке.");
        return null;
    }

    public void PrintEmployes()
    {
        foreach (var employe in Employees)
        {
            Console.WriteLine($"Сотрудник {employe.Name},должность-{employe.JobTitle}");
        }
    }


    public void AddInventory(Inventory inventory)
    {
        _stoсk.AddInventory(inventory);
    }

    public void AddInventoryToEmploye(Employe employe, Inventory inventory)
    {
        employe.AddInventory(inventory);
    }


    public void PrintInventories()
    {
        _stoсk.PrintInventories();
    }
    
    public Inventory FindInventory(string name)
    {
        return _stoсk.FindInventory(name);
    }
    

    public void RemoveInventory(Inventory inventory)
    {
        _stoсk.RemoveInventory(inventory);
    }
   
}