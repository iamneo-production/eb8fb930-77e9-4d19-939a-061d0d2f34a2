using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }//pk

        public string imageUrl { get; set; }
       
        public string ProductName { get; set; }
    
        public int Price { get; set; }
        public string Description { get; set; }
        public int quantity { get; set; }

        //---------------------------------------------------------------------

     
      
        public ICollection<CartModel>? Carts { get; set; }

        //----------------------------------------------------------------------

    }
}
