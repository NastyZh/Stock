namespace ConsoleApp2;

public delegate void Message(string text);
public static class Functional
{
    public static event Message message;
    public static void GetMenu(Company company)
    {
        company.EmployeeRemoved += employeName =>
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine( $"Сотрудник {employeName} удален. Предметы сотрудника отправлены на склад");
            Console.ResetColor();
        };
        Console.WriteLine("Добро пожаловать!");
        while (true)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Выберите пункт меню:\n" +
                                  "1 - Добавить сотрудника.\n" +
                                  "2 - Добавить предмет на склад.\n" +
                                  "3 - Удалить сотрудника.\n" +
                                  "4 - Список сотрудников.\n" +
                                  "5 - Список предметов.\n" +
                                  "6 - Добавить предмет сотруднику.\n" +
                                  "7 - Удалить предмет у сотрудника.\n" +
                                  "8 - Список предметов сотрудника.\n" +
                                  "9 - Удалить предмет со склада.\n" +
                                  "10 - Выход");
                Console.ResetColor();

                var number = Convert.ToInt32(Console.ReadLine()) ;
                string name;
                string jobTitle;
                Employe person;
                int id;
                string model;
                try
                {
                    switch (number)
                    {
                        case 1:
                            Console.WriteLine("Введите имя сотрудника:");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите должность сотрудника:");
                            jobTitle = Console.ReadLine();
                            company.AddEmployee(name, jobTitle);
                            message+=WriteText;
                            message.Invoke(name);
                            message -= WriteText;
                                //=> Console.WriteLine("Сотрудник  добавлен в компанию.");
                           //message?.Invoke("Сотрудник  добавлен в компанию.");
                            //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                           // Console.WriteLine("Сотрудник добавлен в компанию.");
                            //Console.ResetColor();
                            break;
                        case 2:
                            Console.WriteLine("Вы можете добавить:\n" +
                                              "1 - техника.\n" +
                                              "2 - мебель.");
                            Console.WriteLine("Введите пункт меню:");
                            number = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                switch (number)
                                {
                                    case 1:
                                        Console.WriteLine("Введите название предмета");
                                        name = Console.ReadLine();
                                        Console.WriteLine("Введите модель  предмета:");
                                        model = Console.ReadLine();
                                        var technique = new Technique(name, model);
                                        company.AddInventory(technique);
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                        Console.WriteLine("Техника добавлена.");
                                        Console.ResetColor();
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите название предмета");
                                        name = Console.ReadLine();
                                        Console.WriteLine("Введите  цвет предмета:");
                                        model = Console.ReadLine();
                                        var furniture = new Furniture(name, model);
                                        company.AddInventory(furniture);
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                        Console.WriteLine("Мебель добавлена.");
                                        Console.ResetColor();
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                message?.Invoke(Convert.ToString(e));
                            }

                            break;

                        case 3:
                            Console.WriteLine("Введите имя сотрудника:");
                            name = Console.ReadLine();
                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Введено пустое имя.");
                                break;
                            }

                            person = company.FindEmploye(name);
                            if (person == null)
                            {
                                break;
                            }
                            company.RemoveEmployee(person);
                            
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Список сотрудников:");
                            Console.ResetColor();
                            company.PrintEmployes();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Список предметов:");
                            Console.ResetColor();
                            company.PrintInventories();

                            break;
                        case 6:
                            Console.WriteLine("Введите имя сотрудника, которому хотите добавить предмет:");
                            name = Console.ReadLine();

                            person = company.FindEmploye(name);
                            if (person != null)
                            {
                                Console.WriteLine("Какой предмет вы хотите добавить?\n" +
                                                  "1 - мебель.\n" +
                                                  "2 - техника.");

                                id = Convert.ToInt32(Console.ReadLine());
                                AddInventory(id, person, company);
                            }

                            break;
                        case 7:
                            Console.WriteLine("Введите имя сотрудника:");
                            name = Console.ReadLine();
                            person = company.FindEmploye(name);
                            Console.WriteLine("Введите название предмета:");
                            var name1 = Console.ReadLine();
                            var inventory = person.FindInventory(name1);
                            person.RemoveInventory(inventory);
                            company.AddInventory(inventory);
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine($"предмет {inventory.NameInventory} удален у сотрудника {person.Name}");
                            Console.ResetColor();
                            person.PrintInventory();
                            break;
                        case 8:
                            Console.WriteLine("Введите имя сотрудника:");
                            name = Console.ReadLine();
                            person = company.FindEmploye(name);
                            person.PrintInventory();
                            break;
                        case 9:
                            Console.WriteLine("Введите название предмета:");
                            name = Console.ReadLine();
                            inventory = company.FindInventory(name);
                            company.RemoveInventory(inventory);
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("предмет удален со склада");
                            Console.ResetColor();
                            break;
                        case 10:
                            return;
                    }
                }
                catch
                    (Exception e)
                {
                    
                    message?.Invoke(Convert.ToString(e));
                    
                }
            }
            catch (Exception e)
            {
              
                message.Invoke(e.Message);
               
            }
            
        }
    }
    
    public static void AddInventory(int number, Employe employee, Company company)
    {
        Console.WriteLine("Введите название предмета: ");
        var name = Console.ReadLine();
        var inventory = company.FindInventory(name);
        if (inventory == null)
        {
            try
            {
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Введите цвет предмета:");
                        var color = Console.ReadLine();
                        var furniture = new Furniture(name, color);
                        company.AddInventoryToEmploye(employee, furniture);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Предмет добавлен сотруднику.");
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.WriteLine("Введите модель предмета:");
                        var model = Console.ReadLine();
                        var technique = new Technique(name, model);
                        company.AddInventoryToEmploye(employee, technique);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Предмет добавлен сотруднику.");
                        Console.ResetColor();
                        break;
                }
            }
            catch (Exception e)
            {
                message += WriteException;
                message.Invoke(Convert.ToString(e));
                message -= WriteException;
            }
        }

        else
        {
            company.AddInventoryToEmploye(employee,inventory);
        }
    }

    public static void WriteText(string name)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"Сотрудник {name} добавлен в компанию.");
        Console.ResetColor();
    }

    public static void WriteException(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Что-то пошло не так. Попробуйте еще раз.");
        Console.ResetColor();
        Console.WriteLine($"{text}");
    }
}