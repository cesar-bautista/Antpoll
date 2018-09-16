using System.Web.Http;
using Antpoll.Application.Api.Services.Company;
using Antpoll.Domain.Core.Configuration;

namespace Antpoll.Api.Controllers
{
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            var app = UnityConfig.Resolve<ICompanyManagementService>();
            var list = app.GetAll();

            if (list == null)
            {
                return BadRequest(ConfigManager.MsgGetError);
            }

            return Ok(list);
        }
    }
}
