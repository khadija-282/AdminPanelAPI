
using AdminPanelAPI.DTO;
using AdminPanelAPI.Model;
using AdminPanelAPI.Service.Interface;
using CrxApi.ExLogger;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AdminPanelAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class UserController : BaseController
    {
        private IUserService _user;
        private IProfileService _profile;
        private string secret;
        public UserController(IUserService user, IProfileService profile)
        {

            _user = user;
            _profile = profile;
        }
        [HttpPost]
        public ResultDTO Login([FromBody]RequestDTO request)
        {
            try
            {
                UserDTO user = JsonConvert.DeserializeObject<UserDTO>(request.Request.ToString());
                ResultDTO result = GenerateResult(user.Email.Trim());

                UserDTO u = _user.GetUser(user.Email, user.Password);
                if (u == null)
                {
                    result = null;
                    return result;
                }
                bool credentials = u.Password.Trim().Equals(user.Password);
                if (!credentials)
                {
                    result.Result = null;
                }

                result.Result = u;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ResultDTO Register([FromBody]RequestDTO request)
        {
            try
            {
                if (TokenManager.ValidateSecret(request.Secret))
                {
                    var usr = JsonConvert.DeserializeObject<UserRegisterationDTO>(request.Request.ToString());
                    var result = new ResultDTO();
                    var us = _user.RegisterUser(usr.User, usr.Email);
                    var profile = _profile;
                    result.Secret = secret;
                    result.Token = TokenManager.GenerateToken(usr.User.Email);
                    result.Result = us;
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ResultDTO UpdatePassword([FromBody]RequestDTO request)
        {
            try
            {
                var usr = JsonConvert.DeserializeObject<UserDTO>(request.Request.ToString());
                if (TokenManager.ValidateToken(request.Token, request.Secret) != null)
                {
                    var result = new ResultDTO();
                    UserDTO us = _user.UpdatePassword(usr);
                    if (us == null)
                    {
                        result = null;
                        return result;
                    }
                    result.Secret = secret;
                    result.Token = TokenManager.GenerateToken(us.Email);
                    result.Result = us;
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}