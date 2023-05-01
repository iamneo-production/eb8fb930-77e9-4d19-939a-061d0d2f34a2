using dotnetapp.Core;
using dotnetapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly LoginCore loginCore;
        public LoginController(LoginCore loginCore)
        {
            this.loginCore = loginCore;
        }

        [HttpPost]
        [Route("Token")]
        [AllowAnonymous]
        public ResponseModel checkUser([FromBody] LoginModel loginmodel)
        {
            ResponseModel response = null;
            try
            {
                if (loginmodel != null)
                {
                    if (loginmodel.Email !=null && loginmodel.Password != null)
                    {
                       var  respo = loginCore.checkUser(loginmodel);
                        return respo;

                       
                    }
                    else
                    {
                        response = new ResponseModel();
                        response.Message = "Username & password is required";
                        response.Status = false;
                        return response;
                    }
                }
                else
                {
                    response = new ResponseModel();
                    response.Message = "Send proper data in request";
                    response.Status = false;
                    return response;

                }

            }
            catch (System.Exception ex)
            {
                response = new ResponseModel();
                response.Message = " Opps! Something went wrong";
                response.ErrorMessage = ex.Message;
                response.Status = false;
                return response;


            }
        }
    }
}
