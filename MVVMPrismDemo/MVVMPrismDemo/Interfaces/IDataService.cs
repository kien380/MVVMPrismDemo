using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MVVMPrismDemo.Enums;
using MVVMPrismDemo.Models;

namespace MVVMPrismDemo.Interfaces
{
    public interface IDataService
    {
        Task<ObservableCollection<Contact>> GetAllContacts();

        Task<ObservableCollection<Contact>> FindContacts(string name, string phoneNo, Gender gender);

        Task<Contact> InsertContact(Contact contact);

        Task<bool> DeleteContact(int contactId);

        Task<bool> EditContact(Contact contact);
    }
}
