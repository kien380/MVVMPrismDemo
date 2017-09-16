using System.Windows.Input;
using MVVMPrismDemo.Enums;
using MVVMPrismDemo.Managers;
using MVVMPrismDemo.Models;
using Plugin.Messaging;
using Prism.Commands;
using Prism.Navigation;

namespace MVVMPrismDemo.ViewModels
{
    public class DetailContactPageViewModel : ViewModelBase
    {
        public DetailContactPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            EditCommand = new DelegateCommand(EditTask);
            MakeCallCommand = new DelegateCommand(MakeCallTask);
            SendEmailCommand = new DelegateCommand(SendEmailTask);
            SendSmsComand = new DelegateCommand(SendSmsTask);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters != null)
            {
                if (parameters.ContainsKey(NavigationParameterKey.ContactInfo.ToString()))
                {
                    var contact = (Contact) parameters[NavigationParameterKey.ContactInfo.ToString()];
                    Name = contact.Name;
                    PhoneNo = contact.PhoneNo;
                    Gender = contact.Gender.ToString();
                    _contact = contact;
                }
            }
        }

        #region Properties

        private Contact _contact;

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


        private string _avatar;

        public string Avatar
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value);
        }


        private string _phoneNo;

        public string PhoneNo
        {
            get => _phoneNo;
            set => SetProperty(ref _phoneNo, value);
        }


        private string _gender;

        public string Gender
        {
            get => _gender;
            set
            {
                SetProperty(ref _gender, value);
                Avatar = _gender == Enums.Gender.Male.ToString() ? "boy.png" : "girl.png";
            }
        }

        #endregion

        #region Commands

        public ICommand EditCommand { get; set; }

        private void EditTask()
        {
            var navParams = new NavigationParameters()
            {
                { NavigationParameterKey.ContactInfo.ToString(), _contact },
                { NavigationParameterKey.IsEditInfo.ToString(), true }
            };
            NavigationService.NavigateAsync(PageManager.AddNewContactPage, parameters: navParams);
        }


        public ICommand MakeCallCommand { get; set; }

        private void MakeCallTask()
        {
            var phoneTask = CrossMessaging.Current.PhoneDialer;
            phoneTask.MakePhoneCall(PhoneNo, Name);
        }
        

        public ICommand SendSmsComand { get; set; }

        private void SendSmsTask()
        {
            var smsTask = CrossMessaging.Current.SmsMessenger;
            smsTask.SendSms(PhoneNo, "");
        }
        

        public ICommand SendEmailCommand { get; set; }

        private void SendEmailTask()
        {
            var emailTask = CrossMessaging.Current.EmailMessenger;
            emailTask.SendEmail();
        }
        #endregion
    }
}
