using System.Xml.Serialization;

namespace soapStarter.SOAP.Model;

[XmlRoot("Envelope", Namespace = SOAPConstants.SOAP1_1Namespace)]
public partial class SOAPRequestEnvelop
{
  public SOAPHeader? Header {get; set;}
  public SOAPRequestBody? Body {get; set;}
}
