using AddressBookApp.Models;

namespace AddressBookApp;
class Program
{
    static void Main()
    {
        Contact contact = new Contact(
            "Sneha",
            "Gaba",
            "12 Sector-9",
            "Ambala",
            "Haryana",
            "134003",
            "9876543210",
            "snehagaba233@mail.com"
        );

        Console.WriteLine(contact.ToString());
    }
}