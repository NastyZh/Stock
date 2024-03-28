using System;
using System.Runtime.InteropServices.ComTypes;
using ConsoleApp2;
using Newtonsoft.Json;


public class Program
{
    public static void Main()
    {
        var filepath = "company.json";
        var readFile = File.ReadAllText(filepath);

        var company = new Company();
      //  var listEmployes =company.GetListEmployes();
       // JsonConvert.PopulateObject(readFile,listEmployes);
        JsonConvert.PopulateObject(readFile,company);
       
        Functional.GetMenu(company);
        var stringJson = JsonConvert.SerializeObject(company, Formatting.Indented);
       
        File.WriteAllText(filepath,stringJson);

       string readJson= File.ReadAllText(filepath);
       Company? deserializedCompany = JsonConvert.DeserializeObject<Company>(readJson);


    }

    
}