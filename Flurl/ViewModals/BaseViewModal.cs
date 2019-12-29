using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace FlurlProject.ViewModals
{
    public class BaseViewModal : BindableBase, INavigationAware, IInitialize
    {
        protected INavigationService NavigationService { get; private set; }

        public BaseViewModal(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        #region --INavigationAware--

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Initialize(INavigationParameters parameters)
        {
           
        }

        #endregion
    }
}
