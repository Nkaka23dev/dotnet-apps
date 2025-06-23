using System.Collections;

namespace GenericIntro;

public static class Program
{
    public static void Main(string[] args)
    {
        Salaries salaries = new();
        // ArrayList salariesList = salaries.GetSalaries();
        // float salary = (float)salariesList[0];
        List<float> list = salaries.GetSalaries();
        float salary = list[0];
        salary += salary * 0.053f;
        Console.WriteLine(salary);
        Console.ReadLine();
    }
}
public class Salaries
{
    // The value of ArrayList are not strong typed(unboxing and boxing) happens, that is why we choose Generic list for type safety to enhance performance
    // private readonly ArrayList _arrayList = new ArrayList();

    private readonly List<float> _list = new List<float>();

    public Salaries()
    {
        _list.Add(3000.54f);
        _list.Add(2000.5f);
        _list.Add(53583.65f);

        // _arrayList.Add(3000.54);
        // _arrayList.Add(2000.5);
        // _arrayList.Add(53583.65);

        // _arrayList.Add(3000.54f);
        // _arrayList.Add(2000.5f);
        // _arrayList.Add(53583.65f);
    }
      public List<float> GetSalaries()
    {
        return _list;
    }
    // public ArrayList GetSalaries()
    // {
    //     return _arrayList;
    // }
}
