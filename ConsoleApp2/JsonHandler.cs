using Newtonsoft.Json;

namespace ConsoleApp2;

public static class JsonHandler
{
    public static void SerialaseObject(List<Employe> employees)
    {
        
            var stoсkJson = JsonConvert.SerializeObject(employees,Formatting.Indented);
        
            var filePath = Environment.CurrentDirectory + "\\fileEmployes.json";
            File.WriteAllText(filePath,stoсkJson);
        
    }
    
    public static void SerialaseObject(List<Inventory> inventories)
    {
        foreach (var inventory1 in inventories)
        {
            var stoсkJson = JsonConvert.SerializeObject(inventory1,Formatting.Indented);
        
            var filePath = Environment.CurrentDirectory + "\\fileInventory.json";
            File.WriteAllText(filePath,stoсkJson);
        }
        
        // var readFile =File.ReadAllText(filePath);
        // var stockObject = JsonConvert.DeserializeObject<Dictionary<int,Inventory>>(readFile);

    }
}
