internal class Program
{
    private static void Main(string[] args)
    { 
      // string name = "Nkaka \n";
      // string name2 = "Nkaka \"";
      // string name3 = @"My string \n""";//Escaping double quotes
      // Console.WriteLine(name3);

      /*
      String literals, and interpolation
      */

      var myString  = """
      put everthing you want here and will be displyed as you mentioned it
      ,you can try lorem ipsum text
      {}   put everthing you want here and will be displyed as you mentioned it
      ,you can try lorem ipsum text
      {}   put everthing you want here and will be displyed as you mentioned it
      ,you can try lorem ipsum text
      {}
      """;
      Console.WriteLine(myString);
      Console.WriteLine($"Here is my text: {myString}");
      string emptyString = "";//can do this but there is a better way
      string emptyString2 = string.Empty;
    }

}


