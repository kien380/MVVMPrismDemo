using Microsoft.Practices.Unity;
using MVVMPrismDemo.Interfaces;
using MVVMPrismDemo.Managers;
using MVVMPrismDemo.Services;
using MVVMPrismDemo.Views;
using Prism.Unity;
using Xamarin.Forms;

namespace MVVMPrismDemo
{
    public partial class App 
    {
        public App()
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            GetHomePage();
        }

        private void GetHomePage()
        {
            string homePage = PageManager.MultiplePage(new []
            {
                PageManager.HomePage, PageManager.NavigationPage,
                PageManager.PeopleListPage
            });

            NavigationService.NavigateAsync(homePage);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType(typeof(IDataService), typeof(MockDataService),
                new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<NavigationPage>(PageManager.NavigationPage);
            Container.RegisterTypeForNavigation<HomePage>(PageManager.HomePage);

            // Contacts pages
            Container.RegisterTypeForNavigation<PeopleListPage>(PageManager.PeopleListPage);
            Container.RegisterTypeForNavigation<AddNewContactPage>(PageManager.AddNewContactPage);
            Container.RegisterTypeForNavigation<DetailContactPage>(PageManager.DetailContactPage);
        }
    }
}
