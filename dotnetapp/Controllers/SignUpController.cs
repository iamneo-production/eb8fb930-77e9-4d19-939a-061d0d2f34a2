using dotnetapp.Core;
using dotnetapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Text;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly SignUpCore signUpCore;
        public SignUpController(SignUpCore signUpCore)
        {
            this.signUpCore = signUpCore;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<ActionResult<ResponseModel>> SaveUser([FromBody] UserModel user)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                
                if (user != null)
                {
                    var res = signUpCore.RegisterUser(user);
                    responseModel.Response = res;
                    responseModel.Status = true;
                    responseModel.Message = "save sucessfully";
                    return Ok(responseModel);
                }
                return Ok("Enter Proper Data");


            }
            catch (Exception)
            {
                    responseModel.Status = false;
                    responseModel.Message = "Failer";
                    return Ok(responseModel);

                
            }
        }

        
    }
}
