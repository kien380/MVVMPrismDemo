using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MVVMPrismDemo.Enums;
using MVVMPrismDemo.Interfaces;
using MVVMPrismDemo.Managers;
using MVVMPrismDemo.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MVVMPrismDemo.ViewModels
{
    public class PeopleListPageViewModel : ViewModelBase
    {
        private IDataService _dataService;
        private IPageDialogService _dialog;

        public PeopleListPageViewModel(INavigationService navigationService, IDataService dataService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _dataService = dataService;
            _dialog = pageDialogService;

            AddCommand = new DelegateCommand(AddTask);
            DeleteCommand = new DelegateCommand<Contact>(DeleteTask);
            ItemTappedCommand = new DelegateCommand<Contact>(ItemTappedTask);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if(Contacts != null && Contacts.Any())
                return;

            Contacts = await _dataService.GetAllContacts();
        }

        #region Properties
        private ObservableCollection<Contact> _contacts;

        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set => SetProperty(ref _contacts, value);
        }
        #endregion



        #region Commands
        public ICommand AddCommand { get; set; }
        private void AddTask()
        {
            NavigationService.NavigateAsync(PageManager.AddNewContactPage);
        }


        public ICommand DeleteCommand { get; set; }

        private async void DeleteTask(Contact contact)
        {
            bool acceptDelete = await _dialog.DisplayAlertAsync("Message",
                $"Do you want to delete {contact.Name}?",
                "Yes",
                "No");

            if(acceptDelete)
                await _dataService.DeleteContact(contact.Id);
        }


        public ICommand ItemTappedCommand { get; set; }

        private void ItemTappedTask(Contact contact)
        {
            var navParams = new NavigationParameters()
            {
                { NavigationParameterKey.ContactInfo.ToString(), contact }
            };

            NavigationService.NavigateAsync(PageManager.DetailContactPage, parameters: navParams);
        }

        #endregion
    }
}
