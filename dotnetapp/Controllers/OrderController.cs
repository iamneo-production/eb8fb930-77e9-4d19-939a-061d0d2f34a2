using dotnetapp.Core;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Policy;
using System;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder iorder;
        public OrderController(IOrder iorder)
        {
            this.iorder = iorder;

        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<ResponseModel>> GetUserProducts(int id)
        {
            ResponseModel responseModel = null;
            try
            {
                responseModel = new ResponseModel();

                if (id != 0)
                {
                    var order = await iorder.GetUserProducts(id);
                    responseModel = new ResponseModel();

                    responseModel.Response = order;
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    return responseModel;
                }

                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Process Failed";
                    responseModel.ErrorMessage = "Provide Valid Id";
                    return responseModel;
                }





            }
            catch (Exception ex)
            {

                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.ErrorMessage = ex.Message;
//responseModel.ErrorMessage = "Provide Valid Id";
                return responseModel;
            }


        }
        [HttpPost("SaveProduct")]
        public ActionResult<ResponseModel> SaveProduct( int  id, CartModel cartModel)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {


                if (id != 0)
                {

                    //var prod = iorder.SaveProduct( id, cartModel);
                    //responseModel.Response = prod;
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    return responseModel;
                }

                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Process Failed";
                    responseModel.ErrorMessage = "Provide Valid Id";
                    return responseModel;
                }

            }catch (Exception ex)
            {
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.ErrorMessage = ex.Message;
                //responseModel.ErrorMessage = "Provide Valid Id";
                return responseModel;
            }
        }
                [HttpPost("Place")]
                public ResponseModel PlaceOrder(OrderModel order)
                {
                    ResponseModel responseModel = null;
                    try
                    {
                        var res = iorder.PlaceOrder(order);
                        if (res != null)
                        {
                            responseModel = new ResponseModel();
                            responseModel.Response = new
                            {

                                order.ProductName,
                                order.Quantity,
                                order.Price,
                                order.TotalPrice,
                                order.Status,
                                message = "Order Placed"

                            };
                            responseModel.Status = true;
                            responseModel.Message = "Success";
                            return responseModel;
                        }
                        else
                        {
                            responseModel = new ResponseModel();
                            responseModel.Status = false;
                            responseModel.Message = "Failed";
                            responseModel.ErrorMessage = "Error occured while entering Placing Order";
                            return responseModel;
                        }
                    }
                    catch (Exception ex)
                    {

                        responseModel = new ResponseModel();
                        responseModel.Status = false;
                        responseModel.ErrorMessage = ex.Message;
                        //responseModel.ErrorMessage = "Error occured while entering Placing Order";
                        return responseModel;
                    }
                }
            
            
    }
}

        
    





        