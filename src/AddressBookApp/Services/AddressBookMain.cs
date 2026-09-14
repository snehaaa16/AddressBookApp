using AddressBookApp.Exception;
using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        public void Run()
        {
            AddressBook addressBook = new AddressBook();
            while (true)
            {
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Show All Contacts");
                Console.WriteLine("0. Exit");

                Console.Write("> ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        Console.Write("Enter first name: ");
                        string firstName = Console.ReadLine() ?? "";

                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine() ?? "";

                        Console.Write("Enter address: ");
                        string address = Console.ReadLine() ?? "";

                        Console.Write("Enter city: ");
                        string city = Console.ReadLine() ?? "";

                        Console.Write("Enter state: ");
                        string state = Console.ReadLine() ?? "";

                        Console.Write("Enter zip: ");
                        string zip = Console.ReadLine() ?? "";

                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine() ?? "";

                        Console.Write("Enter email: ");
                        string email = Console.ReadLine() ?? "";

                        Contact contact = new Contact(
                            firstName,
                            lastName,
                            address,
                            city,
                            state,
                            zip,
                            phoneNumber,
                            email
                        );

                        try
                        {
                            addressBook.AddContact(contact);
                            Console.WriteLine("Contact added successfully.");
                        }
                        catch (InvalidContactException ex)
                        {
                            Console.WriteLine($"Error: InvalidContactException: {ex.Message}");
                        }

                        break;

                    case "2":
                        addressBook.printAll();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
        }
    }
}
