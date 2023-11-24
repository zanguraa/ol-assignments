using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.ContactList
{
    internal class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();



        public void AddContact(string name, string phone, string email)
        {
            var newContact = new Contact(name, phone, email);
            contacts.Add(newContact);
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }
    }
}
