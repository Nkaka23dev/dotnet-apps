using System.Diagnostics;

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

    // #region WSDL Handling 
    // [HttpGet]
    //     public IActionResult Get(string? wsdl, string? xsd)
    //     {
    //         var controllername = ControllerContext.RouteData.Values["controller"]?.ToString();
    //         if (wsdl is not null)
    //         {
    //             if (string.IsNullOrWhiteSpace(wsdl))
    //                 return BadRequest("WSDL filename must not be empty.");

    //             var path = $"~/wsdl/{(controllerName is null ? "" : controllerName + "/")}{wsdl}";
    //             return ProcessWsdlFile(path)
    //         }
    //         if (xsd is not null)
    //         {
    //             if (xsd == string.Empty)
    //             {
    //                 //TODO: Should be a SOAPFault
    //                 return BadRequest("xsd parameter can not be empty");
    //             }
    //             else
    //             {
    //                 var path = $"~/wsdl/{(controllerName is null ? "" : controllerName + "/")}{xsd}.xml";
    //                 return ProcessWsdlFile(path)
    //             }
    //         }
    //         return  BadRequest("Invalid Request");
    //     }
        
    //     protected ActionResult ProcessWsdlFile(string path){
    //         var _baseURL = $"{Request.Scheme}://" 
    //     }

    //     #endregion

    }