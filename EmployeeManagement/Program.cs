using System;

class Employee
{
    public int EmployeeId;
    public string Name;
    public string Position;
    public double Salary;

    public void Display()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: {Salary}");
    }
}

class EmployeeManagement
{
    static Employee[] employees = new Employee[100]; // Fixed-size array
    static int count = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Employee Management System ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Search Employee");
            Console.WriteLine("3. List All Employees");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1: AddEmployee(); break;
                case 2: SearchEmployee(); break;
                case 3: TraverseEmployees(); break;
                case 4: DeleteEmployee(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void AddEmployee()
    {
        if (count >= employees.Length)
        {
            Console.WriteLine("Array full! Cannot add more employees.");
            return;
        }

        Employee emp = new Employee();

        Console.Write("Enter ID: ");
        emp.EmployeeId = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Name: ");
        emp.Name = Console.ReadLine()!;

        Console.Write("Enter Position: ");
        emp.Position = Console.ReadLine()!;

        Console.Write("Enter Salary: ");
        emp.Salary = double.Parse(Console.ReadLine()!);

        employees[count++] = emp;

        Console.WriteLine("Employee added successfully.");
    }

    static void SearchEmployee()
    {
        Console.Write("Enter Employee ID to search: ");
        int id = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                employees[i].Display();
                return;
            }
        }

        Console.WriteLine("Employee not found.");
    }

    static void TraverseEmployees()
    {
        if (count == 0)
        {
            Console.WriteLine("No employees to display.");
            return;
        }

        Console.WriteLine("Employee List:");
        for (int i = 0; i < count; i++)
        {
            employees[i].Display();
        }
    }

    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to delete: ");
        int id = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                // Shift remaining employees left
                for (int j = i; j < count - 1; j++)
                {
                    employees[j] = employees[j + 1];
                }

                employees[--count] = null!;
                Console.WriteLine("Employee deleted successfully.");
                return;
            }
        }

        Console.WriteLine("Employee not found.");
    }
}

