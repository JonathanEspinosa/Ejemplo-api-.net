using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.VO
{
    public class MasterVO
    {
        public string masCode { get; set; }
        public string name { get; set; }
        public List<DetailVO> detail { get; set; }
    }
}