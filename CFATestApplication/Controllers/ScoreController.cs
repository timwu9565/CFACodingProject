using CFA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CFATestApplication.DTO;

namespace CFATestApplication.Controllers
{
    [RoutePrefix("api/score")]
    public class ScoreController : ApiController
    {
        private readonly ICFAService _CFAService;
        public ScoreController(ICFAService CFAService)
        {
            _CFAService = CFAService;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Score([FromBody]InputDTO inputDTO)
        {
            int res = _CFAService.GetScore(inputDTO.input);
            return Ok(res);
        }
    }
}
