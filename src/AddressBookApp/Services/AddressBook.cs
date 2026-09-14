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
            bool exists = Contacts.Any(contact => contact.FirstName == c.FirstName && contact.LastName == c.LastName);
            if (exists)
            {
                Console.WriteLine($"Contact '{c.FirstName} {c.LastName}' already exists. Duplicate not added.");
                return;
            }
            contacts.Add(c);
            Console.WriteLine("Contact added successfully.");
        }

        public Contact? FindContact(string firstName, string lastName)
        {
            return contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public void UpdateContact(Contact contact)
        {
            ContactValidator validator = new ContactValidator();
            validator.Validate(contact);
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
