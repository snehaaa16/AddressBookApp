using AddressBookApp.Exception;
using AddressBookApp.Models;
using AddressBookApp.Validation;

namespace AddressBookApp;
class Program
{
    static void Main()
    {
        Contact contact = new Contact(
            "Sneha",
            "Gaba",
            "Sector-9",
            "Ambala",
            "Haryana",
            "134003",
            "9876543210",
            "snehagaba233@mail.com"
        );

        Console.WriteLine(contact.ToString());
        Console.WriteLine();
        Console.WriteLine("       ------------------------------------VALIDATION---------------------------------------       ");

        ContactValidator contactValidator = new ContactValidator();

        try
        {
            contactValidator.Validate(contact);
            Console.WriteLine(contact.ToString());
            Console.WriteLine();
            Console.WriteLine("Contact is valid.");
        }
        catch (InvalidContactException ex)
        {
            Console.WriteLine($"Error: InvalidContactException: {ex.Message}");
        }
    }
}