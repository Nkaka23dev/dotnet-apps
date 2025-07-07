using System.ComponentModel;

namespace HeatSensorApp;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("checking programm class");
    }
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
                _hasReachedWarningTemperature = false;
                TemperatureEventArgs e = new()
                {
                    Temperature = temperature,
                    CurrentDateTime = DateTime.Now
                };
                OnTemperatureReachesWarningLevel(e);
            }
            else if (temperature < _warningLevel && _hasReachedWarningTemperature)
            {
                TemperatureEventArgs e = new()
                {
                    Temperature = temperature,
                    CurrentDateTime = DateTime.Now
                };
                OnTemperatureReachesWarningLevel(e);
            }
        }
        
    }

    private void SeedData()
    {
        _temperatureData = [16, 17, 16.5, 18, 19, 22, 24, 26.75, 28.7, 27.6, 26, 24, 22, 46, 68, 86.56];
    }
    protected void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
    {
        EventHandler<TemperatureEventArgs>? handler = _listEventDelegates[_temperatureReachedWarningLevelkey] as EventHandler<TemperatureEventArgs>;
        if (handler != null) {
            handler(this, e);
        }
    }
    protected void OnTemperatureFallBelowWarningLevel(TemperatureEventArgs e)
    {
        EventHandler<TemperatureEventArgs>? handler = _listEventDelegates[_temperatureFallBelowWarningLevelkey] as EventHandler<TemperatureEventArgs>;
        if (handler != null) {
            handler(this, e);
        }
    }

    protected void OnTemperatureReachEmergencyLevel(TemperatureEventArgs e)
    {
        EventHandler<TemperatureEventArgs>? handler = _listEventDelegates[_temperatureReachEmergencyLevelKey] as EventHandler<TemperatureEventArgs>;
        if (handler != null) {
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
        throw new NotImplementedException();
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


