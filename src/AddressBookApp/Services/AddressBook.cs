using System;
using System.Collections.Generic;
using System.Text;
using AddressBookApp.Models;
using AddressBookApp.Validation;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts= new List<Contact>();
        }

        public List<Contact> Contacts
        {
            get { return contacts; }
        }

        public void AddContact(Contact c)
        {
            ContactValidator contactValidator = new ContactValidator();
            contactValidator.Validate(c);
            contacts.Add(c);
        }

        public void printAll()
        {
            foreach(Contact contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}
