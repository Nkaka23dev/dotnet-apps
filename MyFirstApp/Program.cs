internal class User:IDisposable
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public Action? DoSomething { get; set; }
    public Func<int,int,int>? CheckInt {get; set;}
    
    private bool _disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            Console.WriteLine("Disposing managed resources of User...");
        }
        _disposed = true;
        return;
    }
}
 