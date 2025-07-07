using LINQIntro.TCDExtensions;
using LINQIntro.TCPData;

namespace LINQIntro;

public static class Program
{
    public static void Main(string[] args)
    {
        List<string> names = ["Eric", "Clever", "Yvette", "notKnown", "Jon", "Doe", "Jane"];
        List<Employee> employees = Data.GetEmployees();
        List<Department> departments = Data.GetDepartments();
        ///###region 
        /// Mimic a custom LINQ like method(Filter) which I created
        var canRunCustomLINQ1 = false;
        var canRunCustomLINQ2 = false;
        var filterdName = names.Filter(name => name == "Eric");
        var newFilteredName = names.Filter(name => name.ToLower().Contains('e'));

        if (canRunCustomLINQ1)
        {
            foreach (string name in newFilteredName)
            {
                Console.WriteLine(name);
            }
        }
        List<Employee> managerEmployees = employees.Filter(emp => emp.IsManager);
        List<Employee> leastEarningEmployees = employees.Filter(emp => emp.AnnualSalary < 70000);

        if (canRunCustomLINQ2)
        {
            foreach (Employee employee in leastEarningEmployees)
            {
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
                Console.WriteLine();
            }
        }
        ///###endregion

        ///###region 
        /// Equivalent LINQ methods and SQL syntax like for collections of data
        var canRunLINQ1 = false;
        var canRunLINQ2 = false;
        var canRunLINQ3 = true;
        var filteredEmp = employees.Where(emp => !emp.IsManager);
        if (canRunLINQ1)
        {
            foreach (Employee emp in filteredEmp)
            {
                Console.WriteLine($"First Name: {emp.FirstName}");
                Console.WriteLine($"Last Name: {emp.LastName}");
                Console.WriteLine($"Annual Salary: {emp.AnnualSalary}");
                Console.WriteLine();
            }
        }

        var resultList = from empl in employees
                         join dept in departments
                         on empl.DepartmentId equals dept.Id
                         select new
                         {
                             empl.FirstName,
                             empl.LastName,
                             empl.AnnualSalary,
                             Manager = empl.IsManager,
                             Department = dept.LongName
                         };
        if (canRunLINQ2)
        {
            foreach (var employee in resultList)
            {
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
                Console.WriteLine($"Manager: {employee.Manager}");
                Console.WriteLine($"Departement: {employee.Department}");
                Console.WriteLine();
            }
        }

        var usingQueryLikeSyntaxOnNames = from name in names
                                          select new
                                          {
                                               name
                                          };
        Console.WriteLine(usingQueryLikeSyntaxOnNames);
    }
}
