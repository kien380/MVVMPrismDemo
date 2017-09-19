using MVVMPrismDemo.Models;
using MVVMPrismDemo.ViewModels.ContactsPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMPrismDemo.Views.ContactsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeopleListPage : ContentPage
	{
		public PeopleListPage ()
		{
			InitializeComponent ();
		}

	    private void ListViewContacts_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var contact = e.Item as Contact;
	        ListViewContacts.SelectedItem = null;
	        var bindingContext = this.BindingContext as PeopleListPageViewModel;
            bindingContext?.ItemTappedCommand.Execute(contact);
	    }
	}
}