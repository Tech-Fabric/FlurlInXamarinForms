using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FlurlProject.Common;
using FlurlProject.Models;
using FlurlProject.Services;
using Prism.Commands;
using Prism.Navigation;

namespace FlurlProject.ViewModals
{
    public class BrandViewModel : BaseViewModal
    {
        private readonly IBrandService _brandService;

        public BrandViewModel(INavigationService navigationService,
            IBrandService brandService)
            : base(navigationService)
        {
            _brandService = brandService;
        }

        #region --Public properties--

        private Brand _brand;
        public Brand Brand
        {
            get { return _brand; }
            set { SetProperty(ref _brand, value); }
        }

        private bool _isEdit;
        public bool IsEdit
        {
            get { return _isEdit; }
            set { SetProperty(ref _isEdit, value); }
        }

        private ICommand _actionCommand;
        public ICommand ActionCommand
        {
            get { return _actionCommand ?? (_actionCommand = new DelegateCommand(async () => await OnActionCommandAsync())); }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new DelegateCommand(async () => await OnDeleteCommandAsync())); }
        }

        #endregion

        #region --Overrides--

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            if (parameters.TryGetValue(NavigationKeys.Brand, out Brand brand))
            {
                Brand = brand;
                IsEdit = true;
            }
            else
            {
                Brand = new Brand();
            }
        }

        #endregion

        #region --Private helpers--

        private async Task OnActionCommandAsync()
        {
            if (IsEdit)
            {
                await _brandService.UpdateBrandAsync(Brand);
            }
            else
            {
                await _brandService.AddBrandAsync(Brand);

            }

            await NavigationService.GoBackAsync();
        }

        private async Task OnDeleteCommandAsync()
        {
            await _brandService.DeleteBrandAsync(Brand);

            await NavigationService.GoBackAsync();
        }

        #endregion
    }
}
