using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlurlProject.Common;
using FlurlProject.Models;
using Newtonsoft.Json;

namespace FlurlProject.Services
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService()
        {
            _httpClient = new HttpClient();
        }

        public async Task AddBrandAsync(Brand brand)
        {
            var url = $"{AppConstants.BaseUrl}/Brand";

            var jsonString = JsonConvert.SerializeObject(brand);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            try
            {
                await _httpClient.PostAsync(url, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public async Task DeleteBrandAsync(Brand brand)
        {
            var url = $"{AppConstants.BaseUrl}/Brand?id={brand.Id}";

            try
            {
                await _httpClient.DeleteAsync(url);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public async Task<Brand> GetBrandAsync(string id)
        {
            Brand result = null;
            var url = $"{AppConstants.BaseUrl}/Brand?id={id}";

            try
            {
                var resp = await _httpClient.GetAsync(url);
                if (resp.IsSuccessStatusCode)
                {
                    var data = await resp.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Brand>(data);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return result;
        }

        public async Task<IList<Brand>> GetBrandsAsync()
        {
            IList<Brand> result = null;
            var url = $"{AppConstants.BaseUrl}/Brand";

            try
            {
                var resp = await _httpClient.GetAsync(url);
                if (resp.IsSuccessStatusCode)
                {
                    var data = await resp.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<IList<Brand>>(data);
                }
                else
                {
                    result = new List<Brand>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                result = new List<Brand>();
            }

            return result;
        }

        public async Task UpdateBrandAsync(Brand brand)
        {
            var url = $"{AppConstants.BaseUrl}/Brand";

            var jsonString = JsonConvert.SerializeObject(brand);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            try
            {
                await _httpClient.PutAsync(url, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
