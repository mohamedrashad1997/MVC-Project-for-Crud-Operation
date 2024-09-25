using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task.PL.Models
{
    public class ProductViewModel
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
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Valid Price")]
        public int ProductPrice { get; set; }
        [Display(Name = "Product Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Valid Quantity")]
        public int ProductQuantity { get; set; }
        [ForeignKey("Category")]
        [Required]
        public int? CategoryID { get; set; }
    }
}
