using Microsoft.AspNetCore.Mvc.Rendering;

namespace Task.PL.Models
{
    public class ProductUpdateViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int CategoryID { get; set; }

    }
}
