using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AlgoTec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AlgoTec.Controllers
{
    [Route("[controller]")]
    public class SearchAddressController : Controller
    {
        private readonly ILogger<SearchAddressController> _logger;

        public SearchAddressController(ILogger<SearchAddressController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GeoAdminSearch")]
        public async Task<IEnumerable<Attrs>> GeoAdminSearch([FromQuery]string term)
        {
            if (string.IsNullOrEmpty(term)) return null;
            
            var baseUrl = $"https://api3.geo.admin.ch/rest/services/api/SearchServer?searchText={term}&type=locations&origins=address&limit=10";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(baseUrl);
            
                var response = (HttpWebResponse) await request.GetResponseAsync();

                if (response.StatusCode != HttpStatusCode.OK) return null;
                
                var data = response.GetResponseStream();
            
                var reader = new StreamReader(data);
            
                var responseFromServer = await reader.ReadToEndAsync();
            
                response.Close();
                
                var addressResults = JsonConvert.DeserializeObject<GeoadminApiSearch>(responseFromServer);
                var labels = addressResults?.results.Select(x=>x.attrs);

                return labels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}