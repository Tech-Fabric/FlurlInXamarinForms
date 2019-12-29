using System;
using Flurl.Http;
using Flurl.Http.Configuration;
using FlurlProject.Pages;
using FlurlProject.Services;
using FlurlProject.ViewModals;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlurlProject
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<BrandPage, BrandViewModel>();

            //containerRegistry.RegisterSingleton<IBrandService, BrandService>();
            containerRegistry.RegisterSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            containerRegistry.RegisterSingleton<IBrandService, BrandFlurlService>();
        }

        protected async override void OnInitialized()
        {
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }
    }
}
