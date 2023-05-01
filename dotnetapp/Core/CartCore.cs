using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using Microsoft.CodeAnalysis;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace dotnetapp.Core
{
    public class CartCore : ICart
    {
        private readonly LensContext context;
        public CartCore(LensContext context)
        {
            this.context = context;
        }

        public async  Task<ProductModel> AddToCart(int id, int quantity)
        {
            try
            {
                
                var ExistingItem = context.ProductTable.FirstOrDefault(i => i.ProductId == id);
                if (ExistingItem != null)
                {
                    ExistingItem.quantity += quantity;
                  await context.CartTable.AddAsync(new CartModel 
                    { 
                        Quantity = quantity,
                        ProductName = ExistingItem.ProductName,
                        Price = ExistingItem.Price,
                        
                        
                    });
                    await context.SaveChangesAsync();
                    return ExistingItem;
                    
                }
                return null;

             }
            catch (Exception)
            {

                throw;
            }
        }
    

        public Task<int> DeleteCartItem(int id)
        {
            try
            {
                
                var RemoveItem = context.CartTable.FirstOrDefault(i => i.cartitemId == id);
                if (RemoveItem != null)
                {
                    context.Remove(RemoveItem);
                    context.SaveChanges();
                    
                }
                return null;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<CartModel> ShowCart()
        { 
            try
            {
                
                var display = context.CartTable.ToList();
                return display;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
