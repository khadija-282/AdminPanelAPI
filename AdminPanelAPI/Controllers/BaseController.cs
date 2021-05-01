using AdminPanelAPI.DTO;
using AdminPanelAPI.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AdminPanelAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
        private string secret;
        public BaseController()
        {
            secret = ConfigurationManager.AppSettings["Secret"];
        }
        public string ValidateToken(RequestDTO request)
        {
            string isValid = "";
            if (request!=null && request.Token != null)
            {
                isValid = TokenManager.ValidateToken(request.Token, request.Secret);
                if (isValid == null)
                {
                    return null;
                }
            }
            return isValid;
        }
        public ResultDTO GenerateResult(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                var result = new ResultDTO()
                {
                    Secret = secret,
                    Token = TokenManager.GenerateToken(email)
                };
                return result;
            }
            return null;
        }
    }
}
