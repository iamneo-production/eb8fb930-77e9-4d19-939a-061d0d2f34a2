using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Core.Interface
{
    public interface ILogin
    {
        ResponseModel checkUser(LoginModel loginModel);
    }
}
