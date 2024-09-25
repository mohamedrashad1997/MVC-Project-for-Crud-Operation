using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Entities
{
	public class Category
	{
		public int CategoryID { get; set; }
		[Required(ErrorMessage = "Please Enter Valid Category Name")]
		[MaxLength(55)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
		[MaxLength(55)]
        [Display(Name = "Category Description")]
        [Required(ErrorMessage = "Please Enter Valid Category Description")]
        public string CategoryDescription { get; set; }
		public ICollection<Product> Products { get; set;} = new HashSet<Product>();
	}
}
