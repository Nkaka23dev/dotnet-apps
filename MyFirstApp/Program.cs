
public class Employee {
    public required string  FirstName {get; set;}
    public required string LastName {get; set;}
    public double Salary {get; set;}
    public required string Country {get; set;} 
}

public class Person(string FirstName, string LastName){
  public string FirstName {get;} = FirstName;
  public string LastName {get; } = LastName;

  // public override string ToString(){
  //   return $"{FirstName} {LastName}";
  // }
}
internal class Program
{
    private static void Main(string[] args)
    {
     var employees = new List<Employee> {
       new Employee{FirstName = "Eric", LastName= "Nkaka", Salary = 100000, Country ="Rwanda" },
       new Employee{FirstName = "Eric", LastName= "Muhuza", Salary = 50000,  Country ="USA"},
       new Employee{FirstName = "John", LastName= "Doe", Salary = 20000,  Country ="Germany" },
       new Employee{FirstName = "Clever", LastName= "Manzi", Salary = 100000,  Country ="Rwanda"},
       new Employee{FirstName = "James", LastName= "Kwizera", Salary = 50000,  Country ="Germany"},
       new Employee{FirstName = "Eva", LastName= "Nkaka", Salary = 45,  Country ="Rwanda"},
     }; 
      // employees.Add(new Employee{FirstName = "Eva", LastName= "Nkaka", Salary = 45 });
      
    //  var distinctname =
    //   employees
    //   .Where(e => e.Salary >= 0)
    //   .Where(e => e.LastName.StartsWith("N"))
    //   .Select(e => new Person(e.FirstName, e.LastName))
    //   .OrderBy(e => e.LastName)
    //   .Select(e => new {e.FirstName, e.LastName})
    //   .Distinct();
      
      //  foreach(var employee in distinctname){
      //    Console.WriteLine(employee);
      //  }
       //we call ToArray to make sure that LINQ is executed immediately
      //  var names = employees.Select(e => e.Salary).ToArray();
      //  var aggregate =  names.Aggregate((x, y) => x + y);
      //  Console.WriteLine(aggregate);  
  
      // var eric = distinctname.ElementAt(0);  
      
      // Console.WriteLine(eric);

      /*
      If more than one element exist we gonna have errors
      */
      // var eric = distinctname.Single(e => e.FirstName == "Eric");
      // var eric = distinctname.SingleOrDefault(e => e.FirstName == "Eric");

      // var eric = distinctname.First(e => e.FirstName == "Eric");
      // Console.WriteLine(eric);
      // var eric = distinctname.FirstOrDefault(e => e.FirstName == "Eric");
      // Console.WriteLine(eric);
      
      //  var salary = employees.Select(e => e.Salary).ToArray();
      //  var sum = salary.DefaultIfEmpty(0).Sum();
      // //  var max = salary.Max();
      //  Console.WriteLine(sum); 

      var grouped = employees.GroupBy(e => e.Country);

      foreach(var g in grouped){
        Console.WriteLine(g.Key + " Employee");
        Console.WriteLine("---------------------");
        foreach(var i in g){
          Console.WriteLine($"{i.FirstName} {i.LastName}: Salary: {i.Salary}");
        }
      }
    } 
} 