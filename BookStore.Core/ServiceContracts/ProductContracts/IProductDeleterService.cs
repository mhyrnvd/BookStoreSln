using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.ServiceContracts.ProductContracts
{
    public interface IProductDeleterService
    {
        bool DeleteProduct(int id);
    }
}
