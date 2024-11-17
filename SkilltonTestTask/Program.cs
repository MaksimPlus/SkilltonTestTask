using SkilltonTestTask.Models;
using SkilltonTestTask.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
        var repository = new EmployeeRepository();
        while (true)
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Создать запись");
            Console.WriteLine("2. Прочитать записи");
            Console.WriteLine("3. Обновить запись");
            Console.WriteLine("4. Удалить запись");
            Console.WriteLine("5. Выход");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Create(repository);
                    break;
                case "2":
                    Read(repository);
                    break;
                case "3":
                    Update(repository);
                    break;
                case "4":
                    Delete(repository);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }

        }
        void Create(EmployeeRepository repository)
        {
            Employee employee = new Employee();
            employee.FirstName = WriteProperty("фамилию");
            employee.LastName = WriteProperty("имя");
            employee.Email = WriteProperty("электронную почту");
            employee.Salary = decimal.Parse(WriteProperty("зарплату"));
            employee.DateOfBirth = DateTime.Parse(WriteProperty("дату рождения"));
            repository.Add(employee);
        }

        void Read(EmployeeRepository repository)
        {
            var listEmployee = repository.GetAll().ToList();
            foreach (var employee in listEmployee)
            {
                Console.WriteLine("Фамилия {0} Имя {1} Дата рождения {2} Электронная почта {3} Зарплата {4} ", employee.FirstName, employee.LastName, employee.DateOfBirth, employee.Email, employee.Salary);
            }
        }

        void Update(EmployeeRepository repository)
        {

            int id = 0;
            Console.WriteLine("Введите идентификатор пользователя");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                var employee = repository.GetById(id);
                if (employee != null)
                {
                    while (true)
                    {
                        Console.WriteLine("Какие данные вы хотите обновить?");
                        Console.WriteLine("1. Фамилию");
                        Console.WriteLine("2. Имя");
                        Console.WriteLine("3. Дату рождения");
                        Console.WriteLine("4. Электронную почту");
                        Console.WriteLine("5. Зарплату");
                        Console.WriteLine("6. Сохранить и вернуться назад");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                employee.FirstName = WriteProperty("фамилию");
                                break;
                            case "2":
                                employee.FirstName = WriteProperty("имя");
                                break;
                            case "3":
                                employee.DateOfBirth = DateTime.Parse(WriteProperty("дату рождения"));
                                break;
                            case "4":                                
                                    employee.Email = WriteProperty("электронную почту");
                                break;
                            case "5":
                                    employee.Salary = decimal.Parse(WriteProperty("зарплату"));
                                return;
                            case "6":
                                repository.Update(id, employee);
                                return;
                            default:
                                Console.WriteLine("Неверный ввод.");
                                break;
                        }
                    }
                }
                Console.WriteLine("Повторите ввод");
            }
        }
        void Delete(EmployeeRepository repository)
        {
            while (true)
            {
                int id = 0;
                Console.WriteLine("Введите идентификатор пользователя");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    repository.Delete(id);
                    break;
                }
                Console.WriteLine("Повторите ввод");
            }
        }
        bool ValidateStringProperty(string validateString)
        {
            if (validateString != null)
                return true;
            return false;
        }
        bool ValidateDecimalProperty(string validateString)
        {
            decimal salary;
            if (validateString != null && decimal.TryParse(validateString, out salary))
                return true;
            return false;
        }
        bool ValidateDateTimeProperty(string validateString)
        {
            DateTime dateOfBirth;
            if (validateString != null && DateTime.TryParse(validateString, out dateOfBirth))
                return true;
            return false;
        }

        string WriteProperty(string property)
        {
            while (true)
            {
                Console.WriteLine("Введите {0}", property);
                string validateProperty = Console.ReadLine();
                if (property.ToLower() == "зарплату")
                {
                    if (ValidateDecimalProperty(validateProperty))
                        return validateProperty;
                }

                else if (property.ToLower() == "дату рождения")
                {
                    if (ValidateDateTimeProperty(validateProperty))
                        return validateProperty;
                }
                else
                    if (ValidateStringProperty(validateProperty))
                    return validateProperty;
                Console.WriteLine("Введенные данные некорректны, повторите ввод!");
            }
        }
    }
}