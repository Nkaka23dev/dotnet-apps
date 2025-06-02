namespace ShchoolHRAdministration;

class Program
{
    delegate void LogDel(string text);
    static void Main(string[] args)
    {
        Console.WriteLine("Delegate start...");
        Console.WriteLine("Please Enter Your Name");
        var name = Console.ReadLine();

        //Accessign Deleting through static functions
        // LogDel logDel = new LogDel(LogTextToScreen);
        // logDel(name!);
        // Console.ReadKey();

        //Accessing delete function through instance class
        // Log log = new();
        // LogDel logDel = new(log.LogTextToScreen); 
        // logDel(name!);

        //MultiDelagate examples
        Log log = new();
        LogDel logTextToScreenDel, logTextToFileDel;

        logTextToScreenDel = new LogDel(log.LogTextToScreen);
        logTextToFileDel = new LogDel(log.LogTextToFile);

        LogDel multLogDel = logTextToScreenDel + logTextToFileDel;
        // multLogDel(name!);

        //Passing multDelate example in other static function
        LogText(multLogDel, name!);
        Console.ReadKey();
    }

    // A function that takes delate as a parameter
    static void LogText(LogDel logDel, string text)
    {
        logDel(text);
    }

    // static void LogTextToScreen(string text)
    // {
    //     Console.WriteLine($"{DateTime.Now}: {text}");
    // }

    // static void LogTextToFile(string text)
    // {
    //     using (StreamWriter sw = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EricLog.txt"), true))
    //     {
    //         sw.WriteLine($"{DateTime.Now}, {text}");
    //     } 
    //     ;
    // }



}

public class Log
{
    public void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }

    public void LogTextToFile(string text)
    {
        using (StreamWriter sw = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EricLog.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}, {text}");
        }
         ;
    }

}



