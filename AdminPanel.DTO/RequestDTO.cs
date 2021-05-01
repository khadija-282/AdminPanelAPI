using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanelAPI.DTO
{
    public class RequestDTO
    {
        public string Token{ get; set; }
        public string Secret { get; set; }
        public object Request { get; set; }
    }
}