using System.Xml.Serialization;

namespace soapStarter.Model.SOAP;

[XmlType(Namespace = DefaultNamespace)]
public partial class  SOAPRequestBody
{
    public const string DefautNamespacePrefix = "ser";
    public const string DefaultNamespace = "http://some.com/service/";
    public GetWeatherForecastRequest? GetWeatherForecast {get; set;}
}
