
public class Employee {
    public required string  FirstName {get; set;}
    public required string LastName {get; set;}
    public double Salary {get; set;}
}

internal class Program
{
    private static void Main(string[] args)
    {
     var employees = new List<Employee> {
       new Employee{FirstName = "Eric", LastName= "Nkaka", Salary = 100000 },
       new Employee{FirstName = "Eric", LastName= "Muhuza", Salary = 50000 },
       new Employee{FirstName = "John", LastName= "Doe", Salary = 20000 },
       new Employee{FirstName = "Eric", LastName= "Kagame", Salary = 100000 },
       new Employee{FirstName = "James", LastName= "Kwizera", Salary = 50000 },
       new Employee{FirstName = "Eva", LastName= "Nkaka", Salary = 45 },
     }; 

     var distinctname =
      employees
      .Where(e => e.Salary == 100000)
     .Select(e => e.FirstName)
     .Distinct();
     
     foreach(var employee in distinctname){
       Console.WriteLine(employee);
     }

    } 
} 