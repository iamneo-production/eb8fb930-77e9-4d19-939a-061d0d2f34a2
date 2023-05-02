using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Core.Interface
{
    public interface ISignUp
    {
        string RegisterUser(UserModel userModel);
      
    }
}
