﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class CartModel
    {
        [Key]
        public  int cartitemId { get; set; }//PK
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }

        //-------------------------------------------------------------
<<<<<<< HEAD
       
        //------------------------------------------------------------

        
=======
        [ForeignKey(nameof(UserModel))]
        public string? UserId { get; set; } //FK
         public virtual UserModel? User { get; set; }
        //------------------------------------------------------------

       //public ProductModel? Products { get; set; }
        //[ForeignKey(nameof(ProductModel))]
        //public int? productId { get; set; }
        

>>>>>>> Ecommerce-HariniVenkat07
        //-------------------------------------------------------------

        


    }
}
