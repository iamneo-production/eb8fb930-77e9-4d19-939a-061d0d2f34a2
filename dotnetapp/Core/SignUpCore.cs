using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotnetapp.Core
{
    public class SignUpCore : ISignUp
    {

        private readonly LensContext context;
       

        public SignUpCore(LensContext context)
        {
            this.context = context;
           
        }


        public string RegisterUser([FromBody] UserModel userModel)
        {

            try
            {
                
                var response = context.UserTable.Add(userModel);
                context.SaveChanges();
                
                if (response != null)
                {
                    return "Sucessfully Registered";

                }
                else
                {
                    return "Enter Proper Detail";
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}
