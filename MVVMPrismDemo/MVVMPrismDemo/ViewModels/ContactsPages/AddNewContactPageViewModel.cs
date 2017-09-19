using System.Windows.Input;
using MVVMPrismDemo.Enums;
using MVVMPrismDemo.Interfaces;
using MVVMPrismDemo.Models;
using MVVMPrismDemo.ViewModels.BasePages;
using Prism.Commands;
using Prism.Navigation;

namespace MVVMPrismDemo.ViewModels.ContactsPages
{
    public class AddNewContactPageViewModel : ViewModelBase
    {
        private IDataService _dataService;

        public AddNewContactPageViewModel(INavigationService navigationService, IDataService dataService) 
            : base(navigationService)
        {
            _dataService = dataService;

            SaveCommand = new DelegateCommand(SaveTask);
            CancelCommand = new DelegateCommand(CancelTask);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters != null)
            {
                if (parameters.ContainsKey(NavigationParameterKey.ContactInfo.ToString()))
                {
                    var contact = (Contact)parameters[NavigationParameterKey.ContactInfo.ToString()];
                    Name = contact.Name;
                    PhoneNo = contact.PhoneNo;
                    Gender = contact.Gender.ToString();
                    _contact = contact;
                }
                if (parameters.ContainsKey(NavigationParameterKey.IsEditInfo.ToString()))
                {
                    _isEditInfo = (bool)parameters[NavigationParameterKey.IsEditInfo.ToString()];
                }
            }

            PageTitle = _isEditInfo ? "Edit contact" : "Add new contact";
        }

        #region Properties

        private bool _isEditInfo;

        private Contact _contact;

        private string _gender;
        public string Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }


        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


        private string _phoneNo;
        public string PhoneNo
        {
            get => _phoneNo;
            set => SetProperty(ref _phoneNo, value);
        }
        #endregion


        #region Commands

        public ICommand SaveCommand { get; set; }

        private void SaveTask()
        {
            if (_isEditInfo)
            {
                // Todo Edit contact info
                _dataService.EditContact(new Contact()
                {
                    Id = _contact.Id,
                    Name = Name,
                    PhoneNo = PhoneNo,
                    Gender = Gender == Enums.Gender.Male.ToString()
                        ? Enums.Gender.Male
                        : Enums.Gender.Female
                });
            }
            else
            {
                // Todo Insert new contact
                _dataService.InsertContact(new Contact
                {
                    Name = Name,
                    PhoneNo = PhoneNo,
                    Gender = Gender == Enums.Gender.Male.ToString() 
                        ? Enums.Gender.Male 
                        : Enums.Gender.Female
                });
            }

            NavigationService.GoBackAsync();
        }


        public ICommand CancelCommand { get; set; }

        private void CancelTask()
        {
            NavigationService.GoBackAsync();
        }
        #endregion
    }
}
