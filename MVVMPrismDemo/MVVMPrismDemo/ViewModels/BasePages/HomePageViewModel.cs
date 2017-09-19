using System.Windows.Input;
using MVVMPrismDemo.Managers;
using Prism.Navigation;

namespace MVVMPrismDemo.ViewModels.BasePages
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        #region Commands

        public ICommand NavigateCommand { get; set; }

        #endregion
    }
}
