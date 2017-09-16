using System;
using MVVMPrismDemo.Models;
using MVVMPrismDemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMPrismDemo.Views
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