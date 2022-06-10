using Newtonsoft.Json;
using ReversiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReversiMVC.Controllers
{
    public class HttpController
    {
        private readonly IHttpClientFactory _httpCLientFactory;

        public HttpController(IHttpClientFactory _httpCLientFactory)
        {
            this._httpCLientFactory = _httpCLientFactory;
        }
        public async Task<Board> GetBoard(int spelid)
        {
            Board vm = null;
            var request = new HttpRequestMessage(HttpMethod.Get, "Boards/byspel/" + spelid);
            var client = _httpCLientFactory.CreateClient("Api");
            var Response = await client.SendAsync(request);

            if (Response.IsSuccessStatusCode)
            {
                using var stream = await Response.Content.ReadAsStreamAsync();
                string result = await Response.Content.ReadAsStringAsync();
                vm = JsonConvert.DeserializeObject<Board>(result);
            }
            return vm;
        }
        public async Task<List<int[]>> GetMogelijke(int spelid)
        {
            List<int[]> Mogelijke = null;
            var request = new HttpRequestMessage(HttpMethod.Get, "Spels/Mogelijke/" + spelid);
            var client = _httpCLientFactory.CreateClient("Api");
            var Response = await client.SendAsync(request);

            if (Response.IsSuccessStatusCode)
            {
                using var stream = await Response.Content.ReadAsStreamAsync();
                string result = await Response.Content.ReadAsStringAsync();
                Mogelijke = JsonConvert.DeserializeObject<List<int[]>>(result);
            }
            return Mogelijke;
        }
        public async Task<List<int[]>> GetMogelijkeAfgelopen(int spelid)
        {
            List<int[]> Mogelijke = null;
            var request = new HttpRequestMessage(HttpMethod.Get, "Spels/MogelijkeAflopen/" + spelid);
            var client = _httpCLientFactory.CreateClient("Api");
            var Response = await client.SendAsync(request);

            if (Response.IsSuccessStatusCode)
            {
                using var stream = await Response.Content.ReadAsStreamAsync();
                string result = await Response.Content.ReadAsStringAsync();
                Mogelijke = JsonConvert.DeserializeObject<List<int[]>>(result);
            }
            return Mogelijke;
        }

        public async Task<Boolean> ZetMogelijk(int spelid, int rij, int kolom)
        {            //var request = new HttpRequestMessage(HttpMethod.Get, "spels/mogelijk/32/2/3");
            //asfddffdsfddfsdfdsfdsf
            var request = new HttpRequestMessage(HttpMethod.Get, "spels/mogelijk/" + spelid + "/" + rij + "/" + kolom);

            var client = _httpCLientFactory.CreateClient("Api");
            
            var Response = await client.SendAsync(request);

            if(Response.IsSuccessStatusCode)
            {
                using var stream = await Response.Content.ReadAsStreamAsync();
                string result = await Response.Content.ReadAsStringAsync();
                if (result == "true")
                {
                    return true;
                }
                //vm = JsonConvert.DeserializeObject<IEnumerable<SnackViewModel>>(result);
            }
            else
            {
                //vm = new List<SnackViewModel>();
            }

            return false;
        }
        public async Task<Boolean> Doezet(int spelid, int rij, int kolom)
        {            //var request = new HttpRequestMessage(HttpMethod.Get, "spels/mogelijk/32/2/3");

            var request = new HttpRequestMessage(HttpMethod.Put, "spels/zet/" + spelid + "/" + rij + "/" + kolom);

            var client = _httpCLientFactory.CreateClient("Api");
 
            var Response = await client.SendAsync(request);

            if (Response.IsSuccessStatusCode)
            {
                using var stream = await Response.Content.ReadAsStreamAsync();
                string result = await Response.Content.ReadAsStringAsync();
                if (result == "true")
                {
                    return true;
                }
                //vm = JsonConvert.DeserializeObject<IEnumerable<SnackViewModel>>(result);
            }
            else
            {
                //vm = new List<SnackViewModel>();
            }

            return false;
        }
        //api/Spels/Afgelopen/51

        public async Task<Boolean> Afgelopen(int spelid)
        {            //var request = new HttpRequestMessage(HttpMethod.Get, "spels/mogelijk/32/2/3");

            var request = new HttpRequestMessage(HttpMethod.Get, "spels/Afgelopen/" + spelid);

            var client = _httpCLientFactory.CreateClient("Api");

            var Response = await client.SendAsync(request);

            if (Response.IsSuccessStatusCode)
            {
                using var stream = await Response.Content.ReadAsStreamAsync();
                string result = await Response.Content.ReadAsStringAsync();
                if (result == "true")
                {
                    return true;
                }
                //vm = JsonConvert.DeserializeObject<IEnumerable<SnackViewModel>>(result);
            }
            else
            {
                //vm = new List<SnackViewModel>();
            }

            return false;
        }
    }
}
