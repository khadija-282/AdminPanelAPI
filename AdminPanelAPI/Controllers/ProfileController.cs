using AdminPanel.DTO;
using AdminPanelAPI.DTO;
using AdminPanelAPI.Model;
using AdminPanelAPI.Service.Interface;
using Newtonsoft.Json;
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
    public class ProfileController : BaseController
    {
        IProfileService _service;
        private string secret;
        
        public ProfileController(IProfileService service)
        {
            secret = ConfigurationManager.AppSettings["Secret"];
            _service = service;
        }
        [HttpPost]
        public ResultDTO AddProfile([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                if (!String.IsNullOrEmpty(isValid))
                {
                    ProfileDTO user = JsonConvert.DeserializeObject<ProfileDTO>(request.Request.ToString());
                    ProfileDTO u = _service.AddProfile(user);
                    if (u == null)
                    {
                        result = null;
                        return result;
                    }
                    result.Result = u;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ResultDTO GetProfile([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                if (!String.IsNullOrEmpty(isValid))
                { 
                    ProfileDTO user = JsonConvert.DeserializeObject<ProfileDTO>(request.Request.ToString());
                    ProfileDTO u = _service.GetProfileByEmail(user.Email.Trim());
                    if (u == null)
                    {
                        result = AddProfile(request);
                        return result;
                    }
                    result.Result = u;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ResultDTO UpdateProfile([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                if (!String.IsNullOrEmpty(isValid))
                {
                    ProfileDTO user = JsonConvert.DeserializeObject<ProfileDTO>(request.Request.ToString());
                    ProfileDTO u = _service.UpdateProfile(user);
                    if (u == null)
                    {
                        result = null;
                        return result;
                    }
                    result.Result = u;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ResultDTO DeleteProfile([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                if (!String.IsNullOrEmpty(isValid))
                {
                    ProfileDTO user = JsonConvert.DeserializeObject<ProfileDTO>(request.Request.ToString());
                    var u = _service.DeleteProfile(user);
                    result.Result = u;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
