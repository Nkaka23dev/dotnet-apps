internal class Program
{
    private static async Task Main(string[] args)
    {
      // var result1 = await GetDataFromServer1();
      // Console.WriteLine(result1);
      // var result =  await GetDataFromServer2();
      // foreach(var r in result){
      //     Console.WriteLine(r);
      // }


      // await SimulateDownloading();

      // await SimulateRunningTaskinParallel();

      //  await GreetingAfterDelay();

      //  await RunSequential();

      // await RunConcurrentConnections();
    } 
   

  //  public static async Task<bool> TryConnectAsync(string serverName){

  //   for(int attempt = 1; attempt <= 3; attempt++){

  //     Console.WriteLine($"[{serverName}] Attempt {attempt}...");
  //     await Task.Delay(2000);

  //     if(attempt == 3){
  //       return true;
  //     }
  //   }
  //    return false;
  //  }

  //  public static async Task RunConcurrentConnections(){
  //   var server1 = TryConnectAsync("SERVE 1");
  //   var server2 = TryConnectAsync("SERVER 2");
  //   var server3 = TryConnectAsync("SERVER 3");

  //   bool[] result = await Task.WhenAll(server1, server2, server3);
  //   Console.WriteLine("All connections attempt finished!");

  //   for(int i = 0; i < result.Length; i++){
  //      Console.WriteLine($"Server {i+1} success: {result[i]}");
  //   }

  //  } 

    // public static async Task RunSequential(){
    //   await Task.Delay(1000);
    //   Console.WriteLine("First Done");

    //   await Task.Delay(1000);
    //   Console.WriteLine("Second is done");
    // }

    // public static async Task GreetingAfterDelay(){
    //   await Task.Delay(2000);
    //   Console.WriteLine("Hello from async...");
    // }
   
    // public static async Task SimulateRunningTaskinParallel(){
    //   var task1 = Task.Delay(1000);
    //   var task2 = Task.Delay(3000);
    //   var task3 = Task.Delay(2000);
    //   Console.WriteLine("Be patient tasks are running in parallel");
    //   await Task.WhenAll(task1, task2, task3);
    //   Console.WriteLine("All Task completed!");
    // }

    // public static async Task SimulateDownloading(){
    //   Console.WriteLine("Start downloading...");
    //   await Task.Delay(2000);
    //   Console.WriteLine("Finished downloading!😊");
    // }


    //  public static async Task<string> GetDataFromServer1(){
    //   var client  = new HttpClient();
    //   var result =  await client.GetStringAsync("https://google.com");
    //   return result;
    // }  

    // //Similar to promise.all() in javascript
    // public static async Task<string[]> GetDataFromServer2(){
    //   var client  = new HttpClient();
    //   var result1 =  client.GetStringAsync("https://google.com");
    //   var result2 =  client.GetStringAsync("https://twitter.com");
    //   var results = await Task.WhenAll(result1, result2);
    //   return results;
    // }
  
} 