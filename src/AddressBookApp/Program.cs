using AddressBookApp.Exception;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using AddressBookApp.Services;

namespace AddressBookApp;
class Program
{
    static void Main()
    {

        AddressBookMain addressBookMain = new AddressBookMain();
        addressBookMain.Run();
    }
}