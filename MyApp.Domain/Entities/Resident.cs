using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Resident
    {
        public int ResidentId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; } = "";
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Contact {  get; set; }
        public CivilStatus CivilStatus { get; set; }
        public string BloodType { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }

        protected Resident() { }

        public Resident(string firstname, string lastname, string? middleName, DateTime birthDate, string birthPlace, int age, Gender gender, string address, string contact, CivilStatus civilStatus, string bloodType, string occupation, string religion, string nationality, int userId)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentException("Last name is required.");

            if (birthDate > DateTime.Today)
                throw new ArgumentException("Birth date cannot be in the future");

            if (string.IsNullOrWhiteSpace(birthPlace))
                throw new ArgumentException("Birth place is required.");

            if (age < 0)
                throw new ArgumentException("Age must not below zero");

            if (!Enum.IsDefined(typeof(Gender), gender))
                throw new ArgumentOutOfRangeException(nameof(gender), "Invalid gender value.");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required.");

            if (string.IsNullOrWhiteSpace(contact))
                throw new ArgumentException("Contact number is required.");

            if (!Enum.IsDefined(typeof(CivilStatus), civilStatus))
                throw new ArgumentOutOfRangeException(nameof(civilStatus), "Invalid civil status value.");

            if (string.IsNullOrWhiteSpace(bloodType))
                throw new ArgumentException("Blood type is required.");

            if (string.IsNullOrWhiteSpace(occupation))
                throw new ArgumentException("Occupation is required.");

            if (string.IsNullOrWhiteSpace(religion))
                throw new ArgumentException("Religion is required.");

            if (string.IsNullOrWhiteSpace(nationality))
                throw new ArgumentException("Nationality is required.");

            if (userId <= 0)
                throw new ArgumentException("User ID is Invalid.");

            FirstName = firstname;
            MiddleName = middleName;
            LastName = lastname;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            Age = age;
            Gender = gender;
            Address = address;
            Contact = contact;
            CivilStatus = civilStatus;
            BloodType = bloodType;
            Occupation = occupation;
            Religion = religion;
            Nationality = nationality;
            UserId = userId;
        }
        public void UpdateResident(string firstname,string? middlename, string lastname, DateTime birthDate, string birthPlace, int age, Gender gender, string address, string contact, CivilStatus civilStatus, string bloodType, string occupation, string religion, string nationality)
        {

            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentException("Last name is required.");

            if (birthDate > DateTime.Today)
                throw new ArgumentException("Birth date cannot be in the future");

            if (string.IsNullOrWhiteSpace(birthPlace))
                throw new ArgumentException("Birth place is required.");

            if (age < 0)
                throw new ArgumentException("Age must not below zero");

            if (!Enum.IsDefined(typeof(Gender), gender))
                throw new ArgumentOutOfRangeException(nameof(gender), "Invalid gender value.");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required.");

            if (string.IsNullOrWhiteSpace(contact))
                throw new ArgumentException("Contact number is required.");

            if (!Enum.IsDefined(typeof(CivilStatus), civilStatus))
                throw new ArgumentOutOfRangeException(nameof(civilStatus), "Invalid civil status value.");

            if (string.IsNullOrWhiteSpace(bloodType))
                throw new ArgumentException("Blood type is required.");

            if (string.IsNullOrWhiteSpace(occupation))
                throw new ArgumentException("Occupation is required.");

            if (string.IsNullOrWhiteSpace(religion))
                throw new ArgumentException("Religion is required.");

            if (string.IsNullOrWhiteSpace(nationality))
                throw new ArgumentException("Nationality is required.");


            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            Age = age;
            Gender = gender;
            Address = address;
            Contact = contact;
            CivilStatus = civilStatus;
            BloodType = bloodType;
            Occupation = occupation;
            Religion = religion;
            Nationality = nationality;
        }
    }
}
