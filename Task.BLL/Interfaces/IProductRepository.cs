using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entities;

namespace Task.BLL.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<Product> Read();
		Product GetById(int id);
		int Add(Product product);
		int Update(Product product);
		int Delete(int Id);
	}
}
