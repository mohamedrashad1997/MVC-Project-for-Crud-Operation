using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Entities
{
	public class Product
	{
		public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Enter Valid Product Description")]
        [MaxLength(55)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
		[MaxLength(55)]
        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "Please Enter Valid Product Description")]
        public string ProductDescription { get; set; }
		[Column(TypeName = ("money"))]
        [Display(Name = "Product Price")]
        public int ProductPrice { get; set; }
        [Display(Name = "Product Quantity")]
        public int ProductQuantity { get; set; }
		[ForeignKey("Category")]
		public int? CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
