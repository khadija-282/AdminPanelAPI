using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanelAPI.DTO
{
    public class ResultDTO
    {
        public string Secret { get; set; }
        public string Token { get; set; }
        public object Result { get; set; }
    }
}