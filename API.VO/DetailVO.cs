using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.VO
{
    public class DetailVO
    {
        public long detCode { get; set; }
        public string masCode { get; set; }
        public string cameraCode{ get; set; }
        public string feature{ get; set; }

        //public MasterVO masterVO;
    }
}