using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using FlurlProject.Common;
using FlurlProject.Models;
using FlurlProject.Pages;
using FlurlProject.Services;
using Prism.Commands;
using Prism.Navigation;

namespace FlurlProject.ViewModals
{
    public class MainPageViewModel : BaseViewModal
    {
        private readonly IBrandService _brandService;

        public MainPageViewModel(INavigationService navigationService,
            IBrandService brandService)
            :base(navigationService)
        {
            _brandService = brandService;
        }

        #region --Public properties--

        private IList<Brand> _brands;
        public IList<Brand> Brands
        {
            get { return _brands; }
            set { SetProperty(ref _brands, value); }
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new DelegateCommand(async () => await OnAddCommandAsync())); }
        }

        private ICommand _openBrandCommand;
        public ICommand OpenBrandCommand
        {
            get { return _openBrandCommand ?? (_openBrandCommand = new DelegateCommand<Brand>(async (b) => await OnOpenBrandCommandAsync(b))); }
        }

        #endregion

        #region --Overrides--

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await LoadBrands();
        }

        #endregion

        #region --Private helpers--

        private async Task LoadBrands()
        {
            Brands = await _brandService.GetBrandsAsync();
        }

        private Task OnAddCommandAsync()
        {
            return NavigationService.NavigateAsync(nameof(BrandPage));
        }


        private Task OnOpenBrandCommandAsync(Brand brand)
        {
            var param = new NavigationParameters();
            param.Add(NavigationKeys.Brand, brand);
            return NavigationService.NavigateAsync(nameof(BrandPage), param);
        }

        #endregion
    }
}
