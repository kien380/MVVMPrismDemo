using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MVVMPrismDemo.Enums;
using MVVMPrismDemo.Interfaces;
using MVVMPrismDemo.Models;

namespace MVVMPrismDemo.Services
{
    public class MockDataService : IDataService
    {
        private ObservableCollection<Contact> _contacts;
        private int _lastId;

        public MockDataService()
        {
            _contacts = new ObservableCollection<Contact>
            {
                new Contact {Id = 1, Gender = Gender.Male, Name = "Nguyen Van Ty", PhoneNo = "01234567890"},
                new Contact {Id = 2, Gender = Gender.Female, Name = "Tran Thi Buoi", PhoneNo = "0969696969"},
                new Contact {Id = 3, Gender = Gender.Male, Name = "Tran Dut Thang", PhoneNo = "01231131131"},
                new Contact {Id = 4, Gender = Gender.Female, Name = "Le Thi Sung Suong", PhoneNo = "0909990009"}
            };
            _lastId = 4;
        }


        public async Task<ObservableCollection<Contact>> GetAllContacts()
        {
            await Task.Delay(10);
            return _contacts;
        }

        public async Task<ObservableCollection<Contact>> FindContacts(string name = null, string phoneNo = null, Gender gender = Gender.All)
        {
            await Task.Delay(10);
            return _contacts;
        }

        public async Task<Contact> InsertContact(Contact contact)
        {
            await Task.Delay(10);
            contact.Id = ++_lastId;
            _contacts.Add(contact);
            return contact;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            await Task.Delay(10);
            var findContact = _contacts.First(c => c.Id == contactId);
            if (findContact != null)
            {
                _contacts.RemoveAt(_contacts.IndexOf(findContact));
                UpdateLastId();
                return true;
            }
            return false;
        }

        public async Task<bool> EditContact(Contact contact)
        {
            await Task.Delay(10);
            var findContact = _contacts.First(c => c.Id == contact.Id);
            if (findContact != null)
            {
                int index = _contacts.IndexOf(findContact);
                
                findContact.Gender = contact.Gender;
                findContact.Name = contact.Name;
                findContact.PhoneNo = contact.PhoneNo;

                _contacts.RemoveAt(index);
                _contacts.Insert(index, findContact);

                return true;
            }
            return false;
        }

        private void UpdateLastId()
        {
            int maxId = 0;
            foreach (var contact in _contacts)
            {
                if (contact.Id > maxId)
                {
                    maxId = contact.Id;
                }
            }
            _lastId = maxId;
        }
    }
}
