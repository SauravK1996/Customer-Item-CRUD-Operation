using Customer_Item_CRUD_MVC.Models;
using Customer_Item_CRUD_MVC.Repository.IRepository;
using Customer_Item_CRUD_MVC.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_MVC.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;
        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<bool> CreateAsync(string url, ItemNameAndPrice objToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (objToCreate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objToCreate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            //if (token.Length != 0)
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public Task<CustomerItemList> CustomerItemList()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string url)//, decimal id)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);// + id);

            var client = _clientFactory.CreateClient();
            //if (token.Length != 0)
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSalesOrderAsync(string url, decimal id)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url + id);

            var client = _clientFactory.CreateClient();
            //if (token.Length != 0)
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        //done
        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();
            //if (token != null && token.Length != 0)
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
            return null;
        }

        //done
        public async Task<T> GetAsync(string url, decimal id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();
            //if (token != null && token.Length != 0)
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            return null;
        }

        //done
        public async Task<bool> UpdateAsync(string url, UpdateItemRateViewModel objToUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            if (objToUpdate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objToUpdate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            //if (token != null && token.Length != 0)
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }
    }
}
