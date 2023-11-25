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
        public void GetContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
        public List<Contact> SearchContacts(string searchTerm)
        {
            return contacts
                .Where(contact =>
                    contact.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.PhoneNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
