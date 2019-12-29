using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlurlProject.Models;

namespace FlurlProject.Services
{
    public interface IBrandService
    {
        Task<IList<Brand>> GetBrandsAsync();

        Task<Brand> GetBrandAsync(string id);

        Task AddBrandAsync(Brand brand);

        Task UpdateBrandAsync(Brand brand);

        Task DeleteBrandAsync(Brand brand);
    }
}