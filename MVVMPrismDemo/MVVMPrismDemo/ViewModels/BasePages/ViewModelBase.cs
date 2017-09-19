using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MVVMPrismDemo.ViewModels.BasePages
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        #region private & protected field
        protected INavigationService NavigationService { get; }

        private readonly INavigation _navigation;
        #endregion

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
        
        #region General Properties

        private string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        #endregion
    }
}
