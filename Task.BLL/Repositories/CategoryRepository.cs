using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Interfaces;
using Task.DAL.Context;
using Task.DAL.Entities;

namespace Task.BLL.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly TaskDbContext _context;

		public CategoryRepository(TaskDbContext context)
		{
			_context = context;
		}

		public int Add(Category category)
		{
		    _context.Add(category);
			return _context.SaveChanges();
		}
        public IEnumerable<Category> Read()
        {
			var categories =  _context.Categories.ToList();
			return categories;
        }            
    }
}
