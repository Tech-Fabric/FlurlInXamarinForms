using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlurlProject.Common;
using FlurlProject.Models;
using Flurl.Http;
using Flurl;
using System.Diagnostics;
using FlurlProject.Helpers;
using Flurl.Http.Configuration;

namespace FlurlProject.Services
{
    public class BrandFlurlService : IBrandService
    {
        private readonly IFlurlClient _flurlClient;

        public BrandFlurlService(IFlurlClientFactory flurlClientFac)
        {
            _flurlClient = flurlClientFac.Get(AppConstants.BaseUrl);
        }

        public async Task AddBrandAsync(Brand brand)
        {
            try
            {
                await AppConstants.BaseUrl
                    .AppendPathSegment(ApiServices.BrandApi)
                    .PostJsonAsync(brand);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public async Task DeleteBrandAsync(Brand brand)
        {
            try
            {
                await AppConstants.BaseUrl
                    .AppendPathSegment(ApiServices.BrandApi)
                    .SetQueryParam("id", brand.Id)
                    .DeleteAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public async Task<Brand> GetBrandAsync(string id)
        {
            Brand result = null;

            try
            {
                result = await _flurlClient.Request(ApiServices.BrandApi, id)
                    .GetJsonAsync<Brand>();
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

            try
            {
                result = await AppConstants.BaseUrl
                    .AppendPathSegment(ApiServices.BrandApi)
                    .GetJsonAsync<IList<Brand>>();
            }
            catch (FlurlHttpTimeoutException fhte)
            {
                Debug.WriteLine(fhte.StackTrace);
            }
            catch (FlurlParsingException fpe)
            {
                Debug.WriteLine(fpe.StackTrace);
            }
            catch (FlurlHttpException fhe)
            {
                Debug.WriteLine(fhe.StackTrace);
                result = new List<Brand>();
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
            try
            {
                await AppConstants.BaseUrl
                    .AppendPathSegment(ApiServices.BrandApi)
                    .PutJsonAsync(brand);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}