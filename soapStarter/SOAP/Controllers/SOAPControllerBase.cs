using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using soapStarter.ConsumerTestScripts.SOAP;
using soapStarter.SOAP.Model;

namespace soapStarter.SOAP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SOAPControllerBase : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IHostEnvironment _env;
        protected SOAPVersion SOAPVersion { get; init; }
        protected SOAPControllerBase(ILogger logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;

            SOAPControllerAttribute? soapversionAttribute = Attribute.GetCustomAttribute(GetType(), typeof(SOAPControllerAttribute)) as SOAPControllerAttribute;

            if (soapversionAttribute is null)
                throw new Exception("Class deriving from SOAPControllerBase is missing the Controller Attribute");
            else
                SOAPVersion = soapversionAttribute.SOAPVersion;
        }
        public virtual SOAPResponseEnvelope CreateSOAPResponseEnvelope() =>
        SOAPVersion == SOAPVersion.V1_1
         ? new SOAP1_1ResponseEnvelope()
         : new SOAP1_2ResponseEnvelope();
    }
}
