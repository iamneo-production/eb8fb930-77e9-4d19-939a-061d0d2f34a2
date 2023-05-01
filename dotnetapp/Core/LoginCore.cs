using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Linq;
using System.IO;

namespace dotnetapp.Core
{
    public class LoginCore : ILogin
    {
        private readonly LensContext context;
        private readonly IConfiguration configuration;
        

        public LoginCore(LensContext context,IConfiguration configuration)
        {
            this.context = context;
            this.configuration=configuration;
            
        }



        public ResponseModel checkUser(LoginModel loginModel)
        {
            try
            {

                var userExist = context.UserTable.FirstOrDefault(x => x.Email.ToLower() == loginModel.Email.ToLower() && x.Password.ToLower() == loginModel.Password.ToLower());

                if (userExist != null)
                {
                    var role = context.UserTable.Where(x => x.Email == loginModel.Email).Select(y => y.role).FirstOrDefault();
                    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {

                        new Claim("role",role),
                        
                    };

                    var token = new JwtSecurityToken(null , null, claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

                    var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Message = generatedToken.ToString();
                    responseModel.Status = true;
                    return responseModel;
                }

                ResponseModel response = new ResponseModel();
                response.Message = $"NO user found with the {loginModel.Email}";
                response.Status = true;
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
