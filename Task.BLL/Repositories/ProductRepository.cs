using Microsoft.EntityFrameworkCore;
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
	public class ProductRepository : IProductRepository
	{
		private readonly TaskDbContext _context;

		public ProductRepository(TaskDbContext context)
		{
			_context = context;
		}

		public int Add(Product product)
		{
			_context.Add(product);
			return _context.SaveChanges();
		}

        public int Delete(int Id)
        {
            var product = _context.Products.FirstOrDefault(C => C.ProductId == Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                return _context.SaveChanges();
            }
            return 0;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.Local.Where(P=>P.ProductId == id).FirstOrDefault();

			if(product is null)
                product = _context.Products.Where(P => P.ProductId == id).FirstOrDefault();

			return product;
        }

        public IEnumerable<Product> Read()
            => _context.Products.Include(c => c.Category).ToList();

        public int Update(Product product)
		{
			_context.Update(product);
			return _context.SaveChanges();
		}
	}
}
