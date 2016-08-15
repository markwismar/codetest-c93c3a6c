using nSubstringModel;
using nSubstringProcess;
using System;
using System.Web.Http;

namespace nSubstringService.Controllers
{
    public class SubstringServiceController : ApiController
    {        
        // POST: api/SubstringService
        public IHttpActionResult Post(SubstringModel substringModel)
        {

            try {
                //For Testing
                substringModel.StatusMessages.Add("Hello from SubstringServiceController");
             
                SubstringProcessing.ProcessNumber(substringModel);
                return Ok(substringModel);
            }
            catch (Exception ex) {
                return InternalServerError(ex);                                
            }            
        }        
    }
}
