using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using soapStarter.Model.SOAP;

namespace soapStarter.SOAP.Model;

[XmlRoot("Envelope", Namespace = SOAPConstants.SOAP1_1Namespace)]
public class SOAP1_1ResponseEnvelope : SOAPResponseEnvelope{}

[XmlRoot("Envelope", Namespace = SOAPConstants.SOAP1_2Namespace)]
public class SOAP1_2ResponseEnvelope : SOAPResponseEnvelope{}

public abstract partial class SOAPResponseEnvelope
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
 