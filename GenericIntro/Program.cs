namespace GenericIntro;

public static class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = [2, 5, 9, 1, 5, 10, 6];
        string[] names = ["Zoe", "Alice", "John", "Bob", "Eve"];
        Employee[] employees = [
            new Employee { Name = "Bob", Id = 5 },
            new Employee { Name = "Alice", Id = 3 },
            new Employee { Name = "Charlie", Id = 3 },
            new Employee { Name = "Eve", Id = 6 },
            new Employee { Name = "Zara", Id = 2 },
            new Employee { Name = "Mike", Id = 7 },
            new Employee { Name = "Diana", Id = 9 },
            new Employee { Name = "Oscar", Id = 1 },
            new Employee { Name = "Nina", Id = 8 },
            new Employee { Name = "Luke", Id = 3 }
        ];

        SortArray<Employee>.BubbleSort(employees);
        SortArray<int>.BubbleSort(numbers);
        SortArray<string>.BubbleSort(names);
        
        // foreach (string name in names)
        // {
        //     Console.WriteLine($"Name: {name}- ");
        // }
        // foreach (int num in numbers) {
        //     Console.WriteLine($"Number: {num} ");
        // }

        // foreach (Employee item in employees)
        // {
        //     Console.WriteLine(item);
        // }
         foreach (Employee employee in employees) {
            Console.WriteLine($"Name: {employee.Name}, Age:{employee.Id}");
        }
    }
}

public class SortArray<T> where T:IComparable<T>
{
    public static void BubbleSort(T[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    Swap(arr, j);
                }
            }
        }
    }
    public static void Swap(T[] arr, int j)
    {
        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
    }
}

public class Employee: IComparable<Employee> 
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    //This logics is for arrays of objects for simple strings, numbers etc.. logic are not neccessary.
    public int CompareTo(Employee? obj)
    {
        if (obj is not Employee other)
        {
            throw new ArgumentException("Object is not an Employee", nameof(obj));
        }

        return Name.CompareTo(other.Name);
    }
    
    //Overriding string to pring Id and Name
    // public override string ToString()
    // {
    //     return $"{Id}-{Name}";
    // }
}
