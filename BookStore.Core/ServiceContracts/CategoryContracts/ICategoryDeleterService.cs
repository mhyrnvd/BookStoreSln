using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryDeleterService
    {
        bool DeleteCategory(int id);
    }
}
