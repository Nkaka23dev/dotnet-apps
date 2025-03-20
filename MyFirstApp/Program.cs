using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    { 

     try{
      NameGuesserGame();
     }catch(Exception ex){
       Console.WriteLine($"Something went wrong! {ex.Message}");
     }

     Console.WriteLine("OTHER BUSINESS");

    //  try{
    //   NameGuesserGame();
    //  }catch(Exception ex) when (ex.Message.Contains("BC1996")){
    //    Console.WriteLine($"Something went wrong! {ex.Message}");
    //  }

    //  Console.WriteLine("OTHER BUSINESS");
    //  try{
    //    DateTime validDateS = DateTime.Parse("2023-10-14");
    //   // DateTime validDate = DateTime.Parse("dhhdh");
    //   // DateTime validDateS = DateTime.Parse(null);

    //  }
    //  catch(ArgumentNullException ex){
    //    Console.WriteLine($"Something Went wrong!{ex}");
    //  }
    //  catch(FormatException exception){
    //   Console.WriteLine($"Wrong date formatting! {exception}");
    //  }
    //  catch(Exception ex){
    
    //   }
    //  finally{
    //   Console.WriteLine("Here there, How are you doing!");
    //  }
   
    }
  

     public static void NameGuesserGame(){
       Console.WriteLine("You only have 3 chances to try!!!!");
        for(var i = 0; i < 3; i++){
        if (i < 2)
        { 
            Console.WriteLine($"Chance {i + 1} -> Enter your name: ");
        }
        else
        {
            Console.WriteLine($"LAST CHANCE -> Enter your name: ");
        }
        string name = Console.ReadLine() ?? string.Empty;
        Result(name);
      }
     }
     public static void Result(string name){
        /**x
        * Throw your own exception
        **/
        if(string.IsNullOrWhiteSpace(name)){
          throw new MyCustomException("Name is null or empty! BC1996");
        }
          // if(string.IsNullOrWhiteSpace(name)){
          //   throw new ArgumentException("Name is null or empty! BC1996");
          // }
        if(name !=  "Nkaka"){
        Console.WriteLine("Wrong  name!");
          // throw new InvalidOperationException("Name should be Nkaka");
        }else {
          Console.WriteLine("You got it right Great!");
        } 
      }
  
}
public class MyCustomException : Exception
{
  public MyCustomException(string message): base(message){
    Console.WriteLine("FROM CUSTOM EXCEPTION");
  }
}


 