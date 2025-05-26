using System.Xml.Serialization;

namespace soapStarter.Model.SOAP;

[XmlType(Namespace = SOAPRequestBody.DefaultNamespace)]
public class SOAPResponseBody
{
    public const string DefautNamespacePrefix = "ser";
    public const string DefaultNamespace = "http://some.com/service/";
    public GetWeatherForecastResponse? GetWeatherForecastResponse { get; set; }

}
