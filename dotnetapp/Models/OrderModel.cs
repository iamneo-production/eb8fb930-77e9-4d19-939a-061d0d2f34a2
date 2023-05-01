using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class OrderModel
    {
        [Key]
        public int orderId { get; set; } //pk
        //----------------------------------------------------------------
       
       public UserModel? User { get; set; }
        [ForeignKey(nameof(UserModel))]
        public string? UserId { get; set; }//fk

        //---------------------------------------------------------------
       
        public string ProductName { get; set; }
      
        public int Quantity { get; set; }
       
        public int TotalPrice { get; set; }
     
        public string Status { get; set; }
        
        public int Price { get; set; }

        //--------------------------------------------------
        public virtual CartModel Cart { get; set; }
        [ForeignKey(nameof(CartModel))]
        public int cartId { get; set; }

    }
}
