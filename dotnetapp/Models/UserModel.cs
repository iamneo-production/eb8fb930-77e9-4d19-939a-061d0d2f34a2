using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class UserModel
    {
        [Key]
        
        public string Email { get; set; }
       
        public string Password { get; set; }
      
        public string UserName { get; set; }
       
        public string MobileNumber { get; set; }
        
        //public bool Active { get; set; }
      
        public string role { get; set; }

        //[NotMapped]
        public virtual ICollection<OrderModel>? Orders { get; set; }
        //public CartModel Carts { get; set; }

        

    }
}
