using AddressBookApp.Exception;
using AddressBookApp.Models;
using AddressBookApp.Validation;

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        private List<AddressBook> books = new List<AddressBook>();
        public void Run()
        {
            AddressBook addressBook = new AddressBook();
            books.Add(addressBook);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Show All Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4: Delete Contact");
                Console.WriteLine("5. Count Contacts");
                Console.WriteLine("6. Find Contacts by City or State");
                Console.WriteLine("7. Display Contacts Group BY City");
                Console.WriteLine("8. Display Contacts Group BY State");
                Console.WriteLine("9. Display contacts grouped by city, and grouped by state");
                Console.WriteLine("10. Count by city or State");
                Console.WriteLine("0. Exit");


                Console.Write("> ");
                string choice = Console.ReadLine() ?? "";

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
                        }
                        catch (InvalidContactException ex)
                        {
                            Console.WriteLine($"Error: InvalidContactException: {ex.Message}");
                        }
                        break;

                    case "2":
                        addressBook.printAll();
                        break;

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
                        string newFirstName = contact1.FirstName;
                        string newLastName = contact1.LastName;
                        string newAddress = contact1.Address;
                        string newCity = contact1.City;
                        string newState = contact1.State;
                        string newZip = contact1.Zip;
                        string newPhone = contact1.PhoneNumber;
                        string newEmail = contact1.Email;
                        Console.Write($"First name ({contact1.FirstName}): ");
                        string input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(input)) newFirstName = input;

                        Console.Write($"Last name ({contact1.LastName}): ");
                        input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(input)) newLastName = input;

                        Console.Write($"Address ({contact1.Address}): ");
                        input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(input)) newAddress = input;

                        Console.Write($"City ({contact1.City}): ");
                        input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(input)) newCity = input;

                        Console.Write($"State ({contact1.State}): ");
                        input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(input)) newState = input;


                        Console.Write($"Zip ({contact1.Zip}): ");
                        input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(input)) newZip = input;

                        Console.Write($"Phone ({contact1.PhoneNumber}): ");
                        input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(input)) newPhone = input;

                        Console.Write($"Email ({contact1.Email}): ");
                        input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(input)) newEmail = input;

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
                            ContactValidator validator =new ContactValidator();
                            validator.Validate(updatedContact);
                            contact1.FirstName =updatedContact.FirstName;
                            contact1.LastName =updatedContact.LastName;
                            contact1.Address =updatedContact.Address;
                            contact1.City =updatedContact.City;
                            contact1.State =updatedContact.State;
                            contact1.Zip =updatedContact.Zip;
                            contact1.PhoneNumber =updatedContact.PhoneNumber;
                            contact1.Email = updatedContact.Email;
                            Console.WriteLine("Contact updated successfully.");
                        }
                        catch (InvalidContactException ex)
                        {
                            Console.WriteLine($"Error: InvalidContactException: {ex.Message}");
                        }
                        break;

                    case "4":
                        Console.Write("Enter first name to delete: ");
                        string firstNameToDelete = Console.ReadLine() ?? "";

                        Console.Write("Enter last name to delete: ");
                        string lastNameToDelete = Console.ReadLine() ?? "";

                        Contact? contact2 = addressBook.FindContact(firstNameToDelete,lastNameToDelete);
                        if (contact2 == null)
                        {
                            Console.WriteLine("Contact not found.");
                            break;
                        }
                        addressBook.Contacts.Remove(contact2);
                        Console.WriteLine("Contact deleted.");
                        break;
                    case "5":
                        int totalCount = books.Sum(b => b.Contacts.Count);
                        Console.WriteLine($"Total contacts in all address books: {totalCount}");
                        break;

                    case "6":
                        Console.Write("Enter city or state to search: ");
                        string location = Console.ReadLine() ?? "";
                        List<Contact> results = new List<Contact>();
                        foreach (AddressBook book in books)
                        {
                            results.AddRange(book.FindContactsByCityOrState(location));
                        }
                        if (results.Count == 0)
                        {
                            Console.WriteLine("No contacts found.");
                            break;
                        }
                        Console.WriteLine($"Found {results.Count} contact(s):");
                        foreach (Contact c in results)
                        {
                            Console.WriteLine(c);
                        }
                        break;

                    case "7":
                        Console.WriteLine("Enter the city to search: ");
                        city = Console.ReadLine() ;
                        
                        books.SelectMany(b => b.Contacts).Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(c=>Console.WriteLine(c.ToString()));
                        break;

                    case "8":
                        Console.WriteLine("Enter the state to search: ");
                        state = Console.ReadLine();

                        books.SelectMany(b => b.Contacts).Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(c => Console.WriteLine(c.ToString()));
                        break;

                    case "9":
                        Console.WriteLine("----By City-----");
                        city = Console.ReadLine();
                        var allContacts = books.SelectMany(b => b.Contacts).ToList();
                        var contactByCity = allContacts.GroupBy(c => c.City);
                        foreach (var group in contactByCity)
                        {
                            Console.WriteLine($"{group.Key}:");

                            foreach (Contact con in group)
                            {
                                Console.WriteLine(con);
                            }
                        }

                        Console.WriteLine("----By State-----");
                        city = Console.ReadLine();
                        var contactByState = books.SelectMany(b => b.Contacts).GroupBy(c => c.State).ToList();
                        foreach (var group in contactByState)
                        {
                            Console.WriteLine($"{group.Key}:");

                            foreach (Contact con in group)
                            {
                                Console.WriteLine(con);
                            }
                        }

                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

    }
}