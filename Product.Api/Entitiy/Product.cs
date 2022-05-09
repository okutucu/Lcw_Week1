using System;
using System.ComponentModel.DataAnnotations.Schema;
using Product.Api.Common;

namespace Product.Api
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Stock { get; set; }
        public int CategoryId { get; set; }
         
        public DateTime CreatedDate { get; set; }
    }
}
