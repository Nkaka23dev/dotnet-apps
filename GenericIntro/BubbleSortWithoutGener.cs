// namespace GenericIntro;

// public static class Program
// {
//     public static void Main(string[] args)
//     {
//         object[] numbers = [2, 5, 9, 1, 5, 10, 6];
//         string[] names = ["Zoe", "Alice", "John", "Bob", "Eve"];
//         Employee[] employees = [
//             new  Employee { Name = "Bob", Age = 25 },
//             new Employee { Name = "Alice", Age = 30 },
//             new Employee { Name = "Charlie", Age = 35 },
//             new Employee { Name = "Eve", Age = 6 },
//             new Employee { Name = "Zara", Age = 28 },
//             new Employee { Name = "Mike", Age = 32 },
//             new Employee { Name = "Diana", Age = 27 },
//             new Employee { Name = "Oscar", Age = 1 },
//             new Employee { Name = "Nina", Age = 23 },
//             new Employee { Name = "Luke", Age = 3 }
//         ];

//         SortArray.BubbleSort(employees);
//         foreach (Employee item in employees)
//         {
//             Console.WriteLine(item);
//         }
//         //  foreach (Employee employee in employees) {
//         //     Console.WriteLine($"Name: {employee.Name}, Age:{employee.Age}");
//         // }
//     }
// }

// public class SortArray
// {
//     public static void BubbleSort(object[] arr)
//     {
//         int n = arr.Length;
//         for (int i = 0; i < n - 1; i++)
//         {
//             for (int j = 0; j < n - i - 1; j++)
//             {
//                 if (((IComparable)arr[j]).CompareTo(arr[j + 1]) > 0)
//                 {
//                     Swap(arr, j);
//                 }
//             }
//         }
//     }
//     public static void Swap(object[] arr, int j)
//     {
//         (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
//     }
// }

// public class Employee : IComparable
// {
//     public required string Name { get; set; }
//     public required int Age { get; set; }

//     public int CompareTo(object? obj)
//     {
//         if (obj is not Employee other)
//             throw new ArgumentException("Object is not an Employee", nameof(obj));
//         return this.Name.CompareTo(other.Name);
//     }
//     public override string ToString()
//     {
//         return $"{Age}-{Name}";
//     }
// }
