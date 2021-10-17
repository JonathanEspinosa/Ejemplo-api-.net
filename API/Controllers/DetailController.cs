using API.Service.Service;
using API.VO;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [RoutePrefix("Detail")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DetailController : ApiController
    {
        DetailService service = new DetailService();

        /// <summary>
        /// Find details using Master code
        /// </summary>
        /// <param name="masterCode"> Master code</param>
        /// <returns>List of DETAIL or empty object if no exist</returns> 
        [HttpGet]
        [Route("FindByMasterCode/{masterCode}")]
        public List<DetailVO> FindByMasterCode(string masterCode)
        {
            return service.FindByMasterCode(masterCode);
        }

        /// <summary>
        /// Get a specific detail searched by code
        /// </summary>
        /// <param name="detailCode"> code of detail</param>
        /// <returns> Detail object</returns>
        [HttpGet]
        [Route("FindByCode/{detailCode}")]
        public DetailVO FindByDetailCode(long detailCode)
        {
            return service.FindByDetailCode(detailCode);
        }

        /// <summary>
        /// Create new detail
        /// </summary>
        /// <param name="request"> DetailVO for create</param>
        /// <returns>meesages succesfull/error</returns>
        [HttpPost]
        [Route("Create")]
        public string Create([FromBody] DetailVO request)
        {
            return service.Create(request);
        }

        [HttpDelete]
        [Route("DeleteByCode/{detailCode}")]
        public void DeleteByCode(int detailCode)
        {
            service.DeleteByCode(detailCode);
        }

    }
}
