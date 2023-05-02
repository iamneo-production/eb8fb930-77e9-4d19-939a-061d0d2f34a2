using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class UserModel
    {
        [Key]
<<<<<<< HEAD
        [DataType(DataType.EmailAddress)]
=======
        
>>>>>>> Ecommerce-HariniVenkat07
        public string Email { get; set; }
       
        public string Password { get; set; }
      
        public string UserName { get; set; }
       
        public string MobileNumber { get; set; }
        
<<<<<<< HEAD
        
=======
        //public bool Active { get; set; }
>>>>>>> Ecommerce-HariniVenkat07
      
        public string role { get; set; }

        //[NotMapped]
<<<<<<< HEAD
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<OrderModel>? Orders { get; set; }
       
=======
        public virtual ICollection<OrderModel>? Orders { get; set; }
        //public CartModel Carts { get; set; }
>>>>>>> Ecommerce-HariniVenkat07

        

    }
}
