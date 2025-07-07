namespace LINQIntro.TCPData;

public class Data
{
    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = [];
        Employee employee = new() { Id = 1, FirstName = "Alice", LastName = "Smith", AnnualSalary = 85000, IsManager = true, DepartmentId = 4};
        employees.Add(employee);
        employee = new Employee { Id = 2, FirstName = "Bob", LastName = "Johnson", AnnualSalary = 62000, IsManager = false, DepartmentId = 5};
        employees.Add(employee);
        employee = new Employee { Id = 3, FirstName = "Charlie", LastName = "Lee", AnnualSalary = 70000, IsManager = false, DepartmentId = 1 };
        employees.Add(employee);
        employee = new Employee { Id = 4, FirstName = "Diana", LastName = "Nguyen", AnnualSalary = 9000, IsManager = true};
        employees.Add(employee);
        employee = new Employee { Id = 5, FirstName = "Ethan", LastName = "Garcia", AnnualSalary = 500000, IsManager = false };
        employees.Add(employee);

        return employees;
    }

    public static List<Department> GetDepartments()
    {
        List<Department> departments = [];

        departments.Add(new Department { Id = 1, ShortName = "HR", LongName = "Human Resources" });
        departments.Add(new Department { Id = 2, ShortName = "ENG", LongName = "Engineering" });
        departments.Add(new Department { Id = 3, ShortName = "MKT", LongName = "Marketing" });
        departments.Add(new Department { Id = 4, ShortName = "FIN", LongName = "Finance" });
        departments.Add(new Department { Id = 5, ShortName = "OPS", LongName = "Operations" });

        return departments;
    }
}