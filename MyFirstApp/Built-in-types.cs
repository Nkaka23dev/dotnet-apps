// internal class Program
// {
//     private static void Main(string[] args)
//     { 
//       // char myLetter = 'F';//Only one character
//       // bool myBool = true;//boolean values
//       // byte myByte = 255; //8 bit unsigned integer
//       // sbyte mySbyte = -128; //8 bit signed interger
//       // int myInt = 54383883; //32 bits, can also declare unsigned
//       // short myShort = 6373;//16 bits
//       // long myLong = 788383838; //64 bits
//       // float myFloate = 433.35f;//Flaoting point value
//       // double myDauble = 654.33;//doubled
//       // decimal myDecimal  = 3.34673838383383433338M;//
//       /*
//       etc.....
//       */
//         /*
//       DateTime, A really important value
//       */

//       // Console.WriteLine($"{myLetter}, {myBool}, {myByte}, {mySbyte}");
//       // Console.WriteLine(DateTime.UtcNow.AddDays(1));//universal time
//       // Console.WriteLine(DateTime.Now);//local 
//       // DateTime d = DateTime.Parse("09/03/2025 20:40:21");
//       // Console.WriteLine(d);
    
//      int[] arrayOfIntegers = [1,2,3,4,54,3,54];//fixed array
//      string[] arrayOfString = ["Eric"];
//      Console.WriteLine(arrayOfIntegers.Length);
//      Console.WriteLine(arrayOfString[0]); 
//      foreach(char c in "Hello World"){//String is array of characters
//        Console.WriteLine(c);
//      };
//      //Enum accessed
//      var employee = EmployeeType.Employee;
//      Console.WriteLine($"{employee}, HERE IS THE ENUM EMPLOYEE");

//      foreach(var e in Enum.GetValues(typeof(EmployeeType))){
//        Console.WriteLine($"EMPLOYEE TYPE VALUES: {e}");
//      }

//      var myTuple = (42, "Nkaka",true);
//       Console.WriteLine(myTuple.Item1);
//       Console.WriteLine(myTuple.Item2);
//       Console.WriteLine(myTuple.Item3);

//      var myTuple2 = (age:22, name:"Nkaka",programmer:true);
//       Console.WriteLine(myTuple2.age);
//       Console.WriteLine(myTuple2.name);
//       Console.WriteLine(myTuple2.programmer);
 
//      Console.WriteLine(GetEmployee().age);
//      Console.WriteLine(GetEmployee().name); 
    
//     //  int thisInterger = null //Can't do this null is only assignable to class
//     }
//     public static (int age, string name) GetEmployee() {
//       return (22, "Eric");
//     }
//       enum EmployeeType{
//       Manager = 2,
//       Supervisor = 4,
//       Employee = 43
//     }

// }


