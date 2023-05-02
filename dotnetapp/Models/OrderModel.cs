using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class OrderModel
    {
        [Key]
        public int orderId { get; set; } //pk
<<<<<<< HEAD
        //----------------------------------------------------------------
       
        public UserModel User { get; set; }
        [ForeignKey(nameof(UserModel))]
        public string UserId { get; set; }//fk

        //---------------------------------------------------------------
       
        public string ProductName { get; set; }
      
        public int Quantity { get; set; }
       
        public int TotalPrice { get; set; }
     
        public string Status { get; set; }
        
        public int price { get; set; }

        //--------------------------------------------------
        public virtual CartModel Cart { get; set; }
        [ForeignKey(nameof(CartModel))]
        public int cartId { get; set; }

    }
=======
                                         //----------------------------------------------------------------

       

        //---------------------------------------------------------------

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int TotalPrice { get; set; }

        public string Status { get; set; }

        public int price { get; set; }

        //--------------------------------------------------
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual CartModel? Cart { get; set; }
        [ForeignKey(nameof(CartModel))]
        public int? cartId { get; set; }
        //-------------------------------------------
        [System.Text.Json.Serialization.JsonIgnore]
        public UserModel? User { get; set; }
        [ForeignKey(nameof(UserModel))]
        public string? UserId { get; set; }//fk
    }

>>>>>>> Ecommerce-HariniVenkat07
}
