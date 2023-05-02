
using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        
        private readonly ICart cart;
        public  CartController(ICart cart)
        {
            this.cart = cart;
         
        }       
        [HttpPost]
        [Route("AddToCart")]
        public ResponseModel AddToCart(int ProductId, int Quantity)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                   
                var cartitem= cart.AddToCart(ProductId,Quantity);
                responseModel.response = cartitem;
                responseModel.Status = true;
                responseModel.Message = "Added";
                return responseModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("deleteCartItem")]
        public ResponseModel deleteCartItem(int CartItemId)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
               
               var cartitem = cart.DeleteCartItem(CartItemId);
                responseModel.response = cartitem;
                responseModel.Status = true;
                responseModel.Message = "Deleted";
                return responseModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("ShowCart")]
        public ActionResult<List<CartModel>>ShowCart()
        {
            try
            {
               
                var cartitem = cart.ShowCart();
                return cartitem;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
