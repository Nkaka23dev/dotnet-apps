using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using soapStarter.Model.SOAP;

namespace soapStarter.SOAP.Model;

[XmlRoot("Envelope", Namespace = SOAPConstants.SOAP1_1Namespace)]
public class SOAPResponseEnvelop
{
  protected SOAPResponseBody? _body;
  [NotNull]
  public SOAPResponseBody? Body 
  {
    get
     {
        _body ??= new SOAPResponseBody();
        return _body!;
        
     }
     set 
     {
        _body = value;
     }
  }
}
 