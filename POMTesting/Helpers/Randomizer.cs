using Bogus;
using RandomNameGeneratorLibrary;
using System;

namespace Store.Helpers
{
    class Randomizer
    {
        public string generateFirstName() => new Faker().Person.FirstName;

        public string generateLastName() => new Faker().Person.LastName;

        public string generateEmail() => new Faker().Person.Email;

        public string generatePhone() => new Faker().Person.Phone;

        public string generateCompany() => new Faker().Company.CompanyName();

        public string generateAddress() => new Faker().Address.StreetAddress();

        public string generateCity() => new Faker().Address.City();

        public string generateCountryCode() => new Faker().Address.CountryCode();

        public string generatePassword() => new Faker().Internet.Password();
    }
}

