using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entities;

namespace Task.BLL.Interfaces
{
	public interface ICategoryRepository
	{
        IEnumerable<Category> Read();
        int Add(Category category);

	}
}
