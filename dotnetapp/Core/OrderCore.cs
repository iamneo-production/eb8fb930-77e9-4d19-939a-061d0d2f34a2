using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dotnetapp.Core
{
    public class OrderCore : IOrder
    {
        private readonly LensContext Context;
        public OrderCore(LensContext Context)
        {
            this.Context = Context;

        }

        public async Task<IEnumerable<OrderModel>> GetUserProducts(int Id)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();

                var order = await Context.OrderTable.FindAsync(Id);

                if (order != null)
                {
                    var list = await Context.OrderTable.ToListAsync();
                    responseModel.Response = order;
                    responseModel.Message = "Added";
                    responseModel.Status = true;
                    return list;

                }
                responseModel.Message = "Not Added";
                responseModel.Status = false;
                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public OrderModel PlaceOrder(OrderModel order)
        {
            try
            {
                if (order != null)
                {
                   Context.OrderTable.Add(order);
                   Context.SaveChanges();
                    return order;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResponseModel SaveProduct(CartModel cartModels, int id )
        {
            ResponseModel responseModel = null;
            try
            {
                responseModel = new ResponseModel();
                var orderItem = Context.CartTable.FirstOrDefault(i => i.cartitemId == id);
                if (orderItem != null)
                {

                    var product = new OrderModel
                    {
                        ProductName = orderItem.ProductName,
                        Price = orderItem.Price,
                        Quantity = orderItem.Quantity,
                    };
                    var t = Context.OrderTable.Add(product);

                    Context.SaveChanges();
                    responseModel.Response = t;
                    responseModel.Message = "SucessFully Added";
                    responseModel.Status = true;

                    return responseModel;
                }
                responseModel.Message = "Not Added";
                responseModel.Status = false;
                return responseModel;
                

            }
            catch (Exception ex)
            {

                responseModel.Response = ex.Message;
                responseModel.Message = "Not Added";
                responseModel.Status = false;
                return responseModel;
            }
        }

        
    }
}


    
