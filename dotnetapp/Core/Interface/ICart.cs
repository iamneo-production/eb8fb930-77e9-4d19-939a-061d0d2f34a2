using dotnetapp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dotnetapp.Core.Interface
{
    public interface ICart
    {
        Task<ProductModel> AddToCart(int  id,int quanttity);
        Task<int> DeleteCartItem(int id);
        List<CartModel> ShowCart();
    }
}
