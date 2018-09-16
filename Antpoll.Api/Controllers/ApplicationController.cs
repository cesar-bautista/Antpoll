using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Antpoll.Application.Api.Adapters;
using Antpoll.Application.Api.Services.Application;
using Antpoll.Domain.Core.Configuration;
using Antpoll.Domain.Entities;

namespace Antpoll.Api.Controllers
{
    [RoutePrefix("api/application")]
    public class ApplicationController : ApiController
    {
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            var app = UnityConfig.Resolve<IApplicationManagementService>();
            var list = app.GetAll();

            if (list == null)
            {
                return BadRequest(ConfigManager.MsgGetError);
            }

            var generic = new ApiResponse<IEnumerable<ApplicationDto>>(list, Request.GetQueryNameValuePairs());
            return Ok(generic);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add([FromBody]ApplicationEntity item)
        {
            var app = UnityConfig.Resolve<IApplicationManagementService>();
            item.CreationDate = DateTime.UtcNow;
            var newItem = app.Add(item);

            if (newItem == null)
            {
                return BadRequest(ConfigManager.MsgAddError);
            }

            return Ok(newItem);
        }

        [HttpPut]
        [Route("modify")]
        public IHttpActionResult Modify([FromBody]ApplicationEntity item)
        {
            var app = UnityConfig.Resolve<IApplicationManagementService>();
            var newItem = app.Modify(item);

            if (newItem == null)
            {
                return BadRequest(ConfigManager.MsgAddError);
            }

            return Ok(newItem);
        }

        [HttpDelete]
        [Route("remove")]
        public IHttpActionResult Remove(byte applicationId)
        {
            var app = UnityConfig.Resolve<IApplicationManagementService>();

            var result = app.Remove(applicationId);

            if (result == 0)
            {
                return BadRequest(ConfigManager.MsgDelError);
            }

            return Ok(applicationId);
        }
    }
}
