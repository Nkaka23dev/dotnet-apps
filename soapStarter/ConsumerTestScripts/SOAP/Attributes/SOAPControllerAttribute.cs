using Microsoft.AspNetCore.Mvc;
using soapStarter.SOAP.Model;

namespace soapStarter.ConsumerTestScripts.SOAP;

public class SOAPControllerAttribute(SOAPVersion soapVersion) : ProducesAttribute(System.Net.Mime.MediaTypeNames.Application.Xml)
{
    public SOAPVersion SOAPVersion { get; } = soapVersion;
}
