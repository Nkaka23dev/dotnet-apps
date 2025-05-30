using HRadministrationApi;

namespace ShchoolHRAdministration;

class Program
{
    static void Main(string[] args)
    {
        // decimal totalSalaries = 0;
        List<IEmployee> employees = [];
        SeedData(employees);
        // foreach (IEmployee employee in employees)
        // {
        //     totalSalaries += employee.Salary;
        // }
        // Console.WriteLine($"Total Annual Salaries (including bonus): {totalSalaries}");
        Console.WriteLine($"Total Annual Salaries (including bonus): {employees.Sum(e => e.Salary)}");
        Console.ReadKey();
    }
    public static void SeedData(List<IEmployee> employees)
    {
        IEmployee teacher1 = new Teacher
        {
            Id = 1,
            FirstName = "Alice",
            LastName = "Johnson",
            Salary = 48000.00m
        };
        employees.Add(teacher1);
        IEmployee teacher2 = new Teacher
        {
            Id = 2,
            FirstName = "Brian",
            LastName = "Smith",
            Salary = 51500.00m
        };
        employees.Add(teacher2);
        IEmployee headOfDepartment = new HeadOfDepartement
        {
            Id = 3,
            FirstName = "Catherine",
            LastName = "Lee",
            Salary = 49900.00m
        };
        employees.Add(headOfDepartment);
        IEmployee deputeHeadMaster = new DeputeHeadMaster
        {
            Id = 4,
            FirstName = "David",
            LastName = "Ngugi",
            Salary = 53000.00m
        };
        employees.Add(deputeHeadMaster);
        IEmployee headMaster = new HeadMaster
        {
            Id = 5,
            FirstName = "Emily",
            LastName = "Martins",
            Salary = 47500.00m
        };
        employees.Add(headMaster);

    }
}

public class Teacher : EmployeeBase
{
    /// <summary>
    /// Calculating bonus for employees
    /// </summary>
    public override decimal Salary { get => base.Salary * 0.02m; }

}

public class HeadOfDepartement : EmployeeBase
{
     public override decimal Salary { get => base.Salary * 0.03m; }
}
public class DeputeHeadMaster : EmployeeBase
{
     public override decimal Salary { get => base.Salary * 0.04m; }
}

public class HeadMaster : EmployeeBase
{
     public override decimal Salary { get => base.Salary * 0.05m; }
}

