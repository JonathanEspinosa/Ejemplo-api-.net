using API.Model;
using API.Service.Repository;
using API.VO;
using System;
using System.Collections.Generic;

namespace API.Service.Service
{
    public class DetailService
    {
        DetailRepository repository = new DetailRepository();
        public List<DetailVO> FindByMasterCode(string masterCode)
        {
            List<DETAIL> list = repository.FindByMasterCode(masterCode);
            List<DetailVO> responseList = new List<DetailVO>();
            list.ForEach(item =>
            {
                DetailVO response = new DetailVO();
                response.detCode = item.DETCODE;
                response.masCode = item.MASCODE;
                response.cameraCode = item.CAMERACODE;
                response.feature = item.FEATURE;
                responseList.Add(response);
            });
            return responseList;
        }

        public DetailVO FindByDetailCode(long detailCode)
        {
            DETAIL detail = repository.FindByDetailCode(detailCode);
            DetailVO response = new DetailVO();
            response.detCode = detail.DETCODE;
            response.masCode = detail.MASCODE;
            response.cameraCode = detail.CAMERACODE;
            response.feature = detail.FEATURE;
            return response;
        }

        public string Create(DetailVO request)
        {
            DETAIL detail = new DETAIL();
            detail.MASCODE = request.masCode;
            detail.CAMERACODE = request.cameraCode;
            detail.FEATURE = request.feature;
            String response = repository.Create(detail);
            return response;
        }

        internal DetailVO Save(DetailVO detail)
        {
            return repository.save(detail);
        }

        public void DeleteByCode(int detailCode)
        {
            repository.DeleteByCode(detailCode);
        }
    }
}
