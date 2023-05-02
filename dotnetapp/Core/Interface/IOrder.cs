using dotnetapp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace dotnetapp.Core.Interface
{
    public interface IOrder

    {
        Task<IEnumerable<OrderModel>>GetUserProducts(int Id);
        //List<ResponseModel> SaveProduct(int Id);

        OrderModel PlaceOrder(OrderModel order);
        ResponseModel SaveProduct(CartModel cartModels, int id);

    }
}
