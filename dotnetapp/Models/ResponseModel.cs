﻿namespace dotnetapp.Models
{
    public class ResponseModel
    {
        public dynamic response { get; set; }
        public string Message { get; set; }

        public bool? Status { get; set; }

        public string ErrorMessage { get; set; }


    }
}
