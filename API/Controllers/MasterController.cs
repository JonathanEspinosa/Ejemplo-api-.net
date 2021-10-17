using API.Service.Service;
using API.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [RoutePrefix("Master")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MasterController : ApiController
    {
        MasterService service=new MasterService();

        [HttpGet]
        [Route("FindByCode/{masterCode}")]
        public MasterVO FindByCode(string masterCode)
        {
            return service.FindByCode(masterCode);
        }

        [HttpPost]
        [Route("save")]
        public MasterVO FindByCode([FromBody] MasterVO master)
        {
            return service.Save(master);
        }

    }
}
