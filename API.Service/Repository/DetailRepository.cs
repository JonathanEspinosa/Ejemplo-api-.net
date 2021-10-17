using API.Model;
using API.VO;
using System.Collections.Generic;
using System.Linq;

namespace API.Service.Repository
{
    class DetailRepository
    {
        public List<DETAIL> FindByMasterCode(string masterCode)
        {
            ConfiamedEntities entities = new ConfiamedEntities();
            return entities.DETAIL.Where(x => x.MASCODE == masterCode).ToList();
        }

        public DETAIL FindByDetailCode(long detailCode)
        {
            ConfiamedEntities entities = new ConfiamedEntities();
            return entities.DETAIL.FirstOrDefault(x => x.DETCODE == detailCode);
        }

        public string Create(DETAIL detail)
        {
            ConfiamedEntities entities = new ConfiamedEntities();
            entities.DETAIL.Add(detail);
            return entities.SaveChanges() == 1 ? "Detail create" : "Error in service";
        }

        public DetailVO save(DetailVO detail)
        {
            ConfiamedEntities entities = new ConfiamedEntities();
            DETAIL exist = entities.DETAIL.FirstOrDefault(x => x.DETCODE == detail.detCode);
            if (exist == null)
            {
                DETAIL item = new DETAIL();
                item.MASCODE = detail.masCode;
                item.CAMERACODE = detail.cameraCode;
                item.FEATURE = detail.feature;
                Create(item);
                detail.detCode = item.DETCODE;

            }
            else
            {
                exist.MASCODE = detail.masCode;
                exist.CAMERACODE = detail.cameraCode;
                exist.FEATURE = detail.feature;
                entities.SaveChanges();
                detail.detCode = exist.DETCODE;
            }
            return detail;
        }

        internal void DeleteByCode(int detailCode)
        {
            ConfiamedEntities entities = new ConfiamedEntities();
            DETAIL element = entities.DETAIL.FirstOrDefault(x => x.DETCODE == detailCode);
            entities.DETAIL.Remove(element);
            entities.SaveChanges();
        }
    }
}
