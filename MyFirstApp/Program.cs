internal class Program
{
    private static void Main(string[] args)
    { 
        /*int a = MultNumbers(2,6);
        MultNumbers(8996, 2, 3, 7, 5, 6);
        Console.WriteLine($"Hello, World!");
        Console.WriteLine($"Calling the first method: {a}");*/
        Console.WriteLine(IsEven(11));
    }

    public static int MultNumbers(int n1, int n2){
        return n1*n2;
    }
    public static void MultNumbers(int name, params int[] numbers){
        Console.WriteLine($"The numbers are: {numbers[0]}");
       foreach(var number in numbers){
        Console.WriteLine(number);
       }
       Console.WriteLine(name);
    }
    public static bool IsEven(int number){
      if(number % 2 == 0){
        return true;
      }
      return false;
    }
    

}



