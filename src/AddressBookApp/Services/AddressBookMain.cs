using AddressBookApp.Exception;
using AddressBookApp.Models;
using AddressBookApp.Validation;
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
                Console.WriteLine("3. Edit Contact");
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
                    case "3":

                        Console.Write("Enter first name: ");
                        firstName = Console.ReadLine() ?? "";

                        Console.Write("Enter last name: ");
                        lastName = Console.ReadLine() ?? "";

                        Contact? contact1 = addressBook.FindContact(firstName, lastName);

                        if (contact1 == null)
                        {
                            Console.WriteLine("Contact not found.");
                            break;
                        }

                        Console.WriteLine("Contact found. Press Enter to keep the existing value.");

                        Console.Write($"First name ({contact1.FirstName}): ");
                        string newFirstName = Console.ReadLine() ?? "";

                        Console.Write($"Last name ({contact1.LastName}): ");
                        string newLastName = Console.ReadLine() ?? "";

                        Console.Write($"Address ({contact1.Address}): ");
                        string newAddress = Console.ReadLine() ?? "";

                        Console.Write($"City ({contact1.City}): ");
                        string newCity = Console.ReadLine() ?? "";

                        Console.Write($"State ({contact1.State}): ");
                        string newState = Console.ReadLine() ?? "";

                        Console.Write($"Zip ({contact1.Zip}): ");
                        string newZip = Console.ReadLine() ?? "";

                        Console.Write($"Phone ({contact1.PhoneNumber}): ");
                        string newPhone = Console.ReadLine() ?? "";

                        Console.Write($"Email ({contact1.Email}): ");
                        string newEmail = Console.ReadLine() ?? "";

                        newFirstName = newFirstName == "" ? contact1.FirstName : newFirstName;
                        newLastName = newLastName == "" ? contact1.LastName : newLastName;
                        newAddress = newAddress == "" ? contact1.Address : newAddress;
                        newCity = newCity == "" ? contact1.City : newCity;
                        newState = newState == "" ? contact1.State : newState;
                        newZip = newZip == "" ? contact1.Zip : newZip;
                        newPhone = newPhone == "" ? contact1.PhoneNumber : newPhone;
                        newEmail = newEmail == "" ? contact1.Email : newEmail;

                        // Create temporary contact
                        Contact updatedContact = new Contact(
                            newFirstName,
                            newLastName,
                            newAddress,
                            newCity,
                            newState,
                            newZip,
                            newPhone,
                            newEmail
                        );

                        try
                        {
                            ContactValidator validator = new ContactValidator();
                            validator.Validate(updatedContact);

                            contact1.FirstName = updatedContact.FirstName;
                            contact1.LastName = updatedContact.LastName;
                            contact1.Address = updatedContact.Address;
                            contact1.City = updatedContact.City;
                            contact1.State = updatedContact.State;
                            contact1.Zip = updatedContact.Zip;
                            contact1.PhoneNumber = updatedContact.PhoneNumber;
                            contact1.Email = updatedContact.Email;

                            Console.WriteLine("Contact updated successfully.");
                        }
                        catch (InvalidContactException ex)
                        {
                            Console.WriteLine($"Error: InvalidContactException: {ex.Message}");
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
