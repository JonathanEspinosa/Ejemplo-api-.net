using API.Model;
using API.Service.Repository;
using API.VO;
using System;

namespace API.Service.Service
{
    public class MasterService
    {
        MasterRepository repository = new MasterRepository();
        DetailService detailService = new DetailService();
        public MasterVO FindByCode(string masterCode)
        {
            MASTER master = repository.FindByCode(masterCode);
            if (master != null)
            {
                MasterVO response = new MasterVO();
                response.masCode = master.MASCODE;
                response.name = master.NAME;
                response.detail = detailService.FindByMasterCode(masterCode);
                return response;
            }
            else
            {
                return null;
            }
        }

        public MasterVO Save(MasterVO master)
        {
            MASTER exist = repository.FindByCode(master.masCode);
            MASTER item = new MASTER();
            if (exist == null)
            {
                item.MASCODE = master.masCode;
                item.NAME = master.name;
                repository.Create(item);
            }
            else
            {
                repository.Update(master);
            }
            master.detail.ForEach(x =>
            {
                x.masCode = master.masCode;
                x = detailService.Save(x);
            });
            return master;
        }
    }
}
