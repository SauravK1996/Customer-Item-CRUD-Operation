using Customer_Item_CRUD_MVC.Models;
using Customer_Item_CRUD_MVC.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_MVC.Repository
{    
    public class SalesRepository : Repository<SalesOrder>, ISalesRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public SalesRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
