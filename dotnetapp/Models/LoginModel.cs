using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using dotnetapp.Context;

namespace dotnetapp.Models

{
    public class LoginModel
    {
       
        public string Email { get; set; }
        
        public string Password { get; set; }

    }
}
