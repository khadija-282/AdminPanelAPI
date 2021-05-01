using AdminPanel.DTO;
using AdminPanel.IService;
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
    public class EducationController : BaseController
    {
        IEducationService _service;
        private string secret;

        public EducationController(IEducationService service)
        {
            secret = ConfigurationManager.AppSettings["Secret"];
            _service = service;
        }
        [HttpPost]
        public ResultDTO AddEducation([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                 if (!String.IsNullOrEmpty(isValid ))
                {
                    EducationDTO ed = JsonConvert.DeserializeObject<EducationDTO>(request.Request.ToString());
                    var list = _service.AddEducation(ed);
                    if (list == null)
                    {
                        result = null;
                        return result;
                    }
                    result.Result = list;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ResultDTO GetEducationByProfile([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                 if (!String.IsNullOrEmpty(isValid ))
                {
                    EducationDTO ed = JsonConvert.DeserializeObject<EducationDTO>(request.Request.ToString());
                    var list = _service.GetEducationByProfileId(ed.ProfileId);
                    if (list == null)
                    {
                        result = null;
                        return result;
                    }
                    result.Result = list;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ResultDTO GetEducationById([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                 if (!String.IsNullOrEmpty(isValid ))
                {
                    EducationDTO ed = JsonConvert.DeserializeObject<EducationDTO>(request.Request.ToString());
                    var list = _service.GetEducationById(ed.Id);
                    if (list == null)
                    {
                        result = null;
                        return result;
                    }
                    result.Result = list;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ResultDTO UpdateEducation([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                 if (!String.IsNullOrEmpty(isValid ))
                {
                    EducationDTO ed = JsonConvert.DeserializeObject<EducationDTO>(request.Request.ToString());
                    var list = _service.UpdateEducation(ed);
                    if (list == null)
                    {
                        result = null;
                        return result;
                    }
                    result.Result = list;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ResultDTO DeleteEducation([FromBody]RequestDTO request)
        {
            try
            {
                var isValid = ValidateToken(request);
                ResultDTO result = GenerateResult(isValid);
                if (!String.IsNullOrEmpty(isValid))
                {
                    EducationDTO ed = JsonConvert.DeserializeObject<EducationDTO>(request.Request.ToString());
                    var list = _service.DeleteEducation(ed.Id);
                    result.Result = list;
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
