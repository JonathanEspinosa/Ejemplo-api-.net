using API.Model;
using API.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Repository
{
    class MasterRepository
    {
        public MASTER FindByCode(string masterCode)
        {
            ConfiamedEntities entities = new ConfiamedEntities();
            return entities.MASTER.FirstOrDefault(x => x.MASCODE == masterCode);
        }
        public void Create(MASTER master)
        {
            ConfiamedEntities entities = new ConfiamedEntities();
             entities.MASTER.Add(master);
            entities.SaveChanges();

        }
        public MASTER Update(MasterVO master)
        {
            ConfiamedEntities entities = new ConfiamedEntities();
            MASTER item= entities.MASTER.FirstOrDefault(x=>x.MASCODE== master.masCode);
            if (item != null)
            {
                item.NAME = master.name;
            }
            entities.SaveChanges();
            return item;

        }
    }
}
