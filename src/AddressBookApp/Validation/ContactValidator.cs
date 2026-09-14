using AddressBookApp.Exception;
using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookApp.Validation
{
    public class ContactValidator
    {
        public readonly string FirstLastNameRegex = @"^[A-Z][A-Za-z]{2,}$";
        public readonly string AddressRegex = @"^.{4,}$";
        public readonly string CityStateRegex = @"^[A-Za-z]{4,}$";
        public readonly string ZipRegex = @"^[0-9]{6}";
        public readonly string PhoneRegex = @"^[0-9]{10}";
        public readonly string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public bool IsValidFirstName(string firstName)
        {
            return Regex.IsMatch(firstName, FirstLastNameRegex);
        }

        public bool IsValidLastName(string lastName)
        {
            return Regex.IsMatch(lastName, FirstLastNameRegex);
        }

        public bool IsAddressValid(string address)
        {
            return Regex.IsMatch(address, AddressRegex);
        }

        public bool IsCityValid(string city)
        {
            return Regex.IsMatch(city, CityStateRegex);
        }
        public bool IsStateValid(string state)
        {
            return Regex.IsMatch(state, CityStateRegex);
        }

        public bool IsZipValid(string zip)
        {
            return Regex.IsMatch(zip, ZipRegex);
        }

        public bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, PhoneRegex);
        }

        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, EmailRegex);
        }

        public void Validate(Contact c)
        {
            if (!IsValidFirstName(c.FirstName))
            {
                throw new InvalidContactException("First name must start with a capital letter and be at least 3 characters.");
            }

            if (!IsValidLastName(c.LastName))
            {
                throw new InvalidContactException("Last name must start with a capital letter and be at least 3 characters.");
            }

            if (!IsAddressValid(c.Address))
            {
                throw new InvalidContactException("Address must be at least 4 characters.");
            }

            if (!IsCityValid(c.City))
            {
                throw new InvalidContactException("City must be at least 4 characters.");
            }
            if (!IsStateValid(c.State))
            {
                throw new InvalidContactException("State must be at least 4 characters.");
            }

            if (!IsZipValid(c.Zip))
            {
                throw new InvalidContactException("Zip must contain exactly 6 digits.");
            }

            if (!IsValidPhoneNumber(c.PhoneNumber))
            {
                throw new InvalidContactException("Phone number must contain exactly 10 digits.");
            }

            if (!IsValidEmail(c.Email))
            {
                throw new InvalidContactException("Invalid email format.");
            }
        }
    }
}
