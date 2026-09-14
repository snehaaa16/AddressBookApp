using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.Exception
{
    public class InvalidContactException : System.Exception
    {
        public InvalidContactException(string message): base(message) { }
    }
}
