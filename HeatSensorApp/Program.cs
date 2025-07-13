using System.ComponentModel;

namespace HeatSensorApp;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Press any key to start the device...");
        Console.ReadKey();
        IDevice device = new Device();
        device.RunDevice();
        Console.ReadKey();
    }
}
public class Device : IDevice
{
    private const double warning_Level = 27;
    private const double emergency_Level = 75;

    public double WaringTemperatureLevel => warning_Level;
    public double EmergencyTemperatureLevel => emergency_Level;

    public void HandleEmergency()
    {
        Console.WriteLine();
        Console.WriteLine("Sending out notification to emergency services personal...");
        ShutDownDevice();
        Console.WriteLine();
    }
    private static void ShutDownDevice()
    {
        Console.WriteLine("Shuttin down device...");
    }
    public void RunDevice()
    {
        Console.WriteLine("The divice is running...");
        ICoolingMechanism coolingMechanism = new CoolingMechanism();
        IHeatSensor heatSensor = new HeatSensor(warning_Level, emergency_Level);
        IThermostat thermostat = new Thermostat(this, coolingMechanism, heatSensor);
        thermostat.RunThermostat();
    }
}
public class CoolingMechanism : ICoolingMechanism
{
    public void Off()
    {
        Console.WriteLine();
        Console.WriteLine("Switching cooling mechanism off...");
        Console.WriteLine();
    }

    public void On()
    {
        Console.WriteLine();
        Console.WriteLine("Switching cooling mechanism on...");
        Console.WriteLine();
    }
}
public class Thermostat(IDevice device, ICoolingMechanism coolingMechanism, IHeatSensor heatSensor) : IThermostat
{
    private readonly ICoolingMechanism _coolingMechanism = coolingMechanism;
    private readonly IHeatSensor _heatSensor = heatSensor;
    private readonly IDevice _device = device;

    // //Store warning temperature level in celcius
    // private const double WarningLevel = 27;
    // private const double EmergencyLevel = 75;

    private void WireUpEventsToEventHandlers()
    {
        _heatSensor.TemperatureReachedWarningLevelEventHandler += HeatSensor_TemperatureReachedWarningLevelEventHandler;
        _heatSensor.TemperatureReachedEmergencyLevelEventHandler += HeatSensor_TemperatureReachedEmergencyLevelEventHandler;
        _heatSensor.TemperatureFallBelowWarningLevelEventHandler += HeatSensor_TemperatureFallBelowWarningLevelEventHandler;
    }
    private void HeatSensor_TemperatureReachedEmergencyLevelEventHandler(object? sender, TemperatureEventArgs e)
    {

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine($"Emergency Alert!! (emergency level is between{_device.EmergencyTemperatureLevel} and above.)");
        _device.HandleEmergency();
        Console.ResetColor();
    }
    private void HeatSensor_TemperatureFallBelowWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Information Alert!! Temperature falls below warning level (warning level is between{_device.WaringTemperatureLevel} and {_device.EmergencyTemperatureLevel})");
        _coolingMechanism.Off();
        Console.ResetColor();
    }

    private void HeatSensor_TemperatureReachedWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Warning Alert!! (warning level is between{_device.WaringTemperatureLevel} and {_device.EmergencyTemperatureLevel})");
        _coolingMechanism.On();
        Console.ResetColor();

    }
    public void RunThermostat()
    {
        Console.WriteLine("Thermostart is running....");
        WireUpEventsToEventHandlers();
        _heatSensor.RunHeatSensor();
    }
}
public interface IThermostat
{
    void RunThermostat();
}
public interface IDevice
{
    double WaringTemperatureLevel { get; }
    double EmergencyTemperatureLevel { get; }
    void RunDevice();
    void HandleEmergency();
}
public interface ICoolingMechanism
{
    void On();
    void Off();

}
public class HeatSensor : IHeatSensor
{
    readonly double _warningLevel;
    readonly double _emergencyLevel;
    bool _hasReachedWarningTemperature = false;
    protected EventHandlerList _listEventDelegates = new EventHandlerList();
    static readonly object _temperatureReachedWarningLevelkey = new object();
    static readonly object _temperatureFallBelowWarningLevelkey = new();
    static readonly object _temperatureReachEmergencyLevelKey = new();

    public HeatSensor(double warningLevel, double emergencyLevel)
    {
        _warningLevel = warningLevel;
        _emergencyLevel = emergencyLevel;
        SeedData();
    }
    //Store Mock data to simulate temperature coming from the heat sensor at regural time period
    private double[] _temperatureData = [];

    private void MonitorTemperature()
    {
        foreach (double temperature in _temperatureData)
        {
            Console.ResetColor();
            Console.WriteLine($"DateTime: {DateTime.Now}, Temperature: {temperature}");

            if (temperature >= _emergencyLevel)
            {
                TemperatureEventArgs e = new()
                {
                    Temperature = temperature,
                    CurrentDateTime = DateTime.Now
                };
                OnTemperatureReachEmergencyLevel(e);

            }
            else if (temperature >= _warningLevel)
            {
                _hasReachedWarningTemperature = true;

                TemperatureEventArgs e = new()
                {
                    Temperature = temperature,
                    CurrentDateTime = DateTime.Now
                };
                OnTemperatureReachesWarningLevel(e);
            }
            else if (temperature < _warningLevel && _hasReachedWarningTemperature)
            {
                _hasReachedWarningTemperature = true;

                TemperatureEventArgs e = new()
                {
                    Temperature = temperature,
                    CurrentDateTime = DateTime.Now
                };
                OnTemperatureFallBelowWarningLevel(e);
            }
            // Console.WriteLine("sleeping 1000 milliseconds");
            Thread.Sleep(1000);
        }

    }

    private void SeedData()
    {
        _temperatureData = [16, 17, 16.5, 18, 19, 22, 24, 26.75, 28.7, 27.6, 26, 24, 22, 46, 68, 86.56];
    }
    //        private void SeedData()
    // {
    //     var random = new Random();
    //     _temperatureData = [];

    //     for (int i = 0; i < 40; i++) // generate 16 random temperatures
    //     {
    //         int temperature = random.Next(10, 101); // inclusive 10, exclusive 101
    //         _temperatureData.Add(temperature);
    //     }
    // }
    protected void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
    {
        EventHandler<TemperatureEventArgs>? handler = _listEventDelegates[_temperatureReachedWarningLevelkey] as EventHandler<TemperatureEventArgs>;
        if (handler != null)
        {
            handler(this, e);
        }
    }
    protected void OnTemperatureFallBelowWarningLevel(TemperatureEventArgs e)
    {
        EventHandler<TemperatureEventArgs>? handler = _listEventDelegates[_temperatureFallBelowWarningLevelkey] as EventHandler<TemperatureEventArgs>;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    protected void OnTemperatureReachEmergencyLevel(TemperatureEventArgs e)
    {
        EventHandler<TemperatureEventArgs>? handler = _listEventDelegates[_temperatureReachEmergencyLevelKey] as EventHandler<TemperatureEventArgs>;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachedWarningLevelEventHandler
    {
        add
        {
            _listEventDelegates.AddHandler(_temperatureReachedWarningLevelkey, value);
        }

        remove
        {
            _listEventDelegates.RemoveHandler(_temperatureReachedWarningLevelkey, value);
        }
    }
    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureFallBelowWarningLevelEventHandler
    {
        add
        {
            _listEventDelegates.AddHandler(_temperatureFallBelowWarningLevelkey, value);
        }

        remove
        {
            _listEventDelegates.RemoveHandler(_temperatureFallBelowWarningLevelkey, value);
        }
    }

    event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachedEmergencyLevelEventHandler
    {
        add
        {
            _listEventDelegates.AddHandler(_temperatureReachEmergencyLevelKey, value);

        }

        remove
        {
            _listEventDelegates.RemoveHandler(_temperatureReachEmergencyLevelKey, value);
        }
    }

    public void RunHeatSensor()
    {
        Console.WriteLine("Heat Sensor is running....");
        MonitorTemperature();
    }
}
public interface IHeatSensor
{
    event EventHandler<TemperatureEventArgs> TemperatureReachedEmergencyLevelEventHandler;
    event EventHandler<TemperatureEventArgs> TemperatureReachedWarningLevelEventHandler;
    event EventHandler<TemperatureEventArgs> TemperatureFallBelowWarningLevelEventHandler;
    public void RunHeatSensor();
}

public class TemperatureEventArgs : EventArgs
{
    public double Temperature { get; set; }
    public DateTime CurrentDateTime { get; set; }
}


