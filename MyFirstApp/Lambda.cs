// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         // Func<int, int,int> mult =  (x, y) => x * y; 
    
//         // Console.WriteLine((4,5));

//         // Action doSomething = () => Console.WriteLine("Hello There!");
//         // doSomething();

//         // Action<string> write = Console.WriteLine;
//         // write("hellll");

//         Func<int, int> ImplementClosure(){
//             int counter = 0;
//             Func<int, int> increment = num => {
//                 counter = counter + num;
//                 return counter;
//             };
//             return increment;
//         }
//         var Incrementer = ImplementClosure();
//         Console.WriteLine(Incrementer(2));
//         Console.WriteLine(Incrementer(2));
//         Console.WriteLine(Incrementer(2));

//         int incrementerWithoutCloser(int num){
//          int counter = 0;
//          return counter + num;
//         }

//         Console.WriteLine(incrementerWithoutCloser(5));
//         Console.WriteLine(incrementerWithoutCloser(5));
//         Console.WriteLine(incrementerWithoutCloser(5));
//         //     static void ProcessNumber(int number, Func<int, int> operation){
//         //     int result = operation(number);
//         //     Console.WriteLine($"Results: {result}");
//         //  }
//         //    ProcessNumber(5, x => x / x);


//     } 
// }