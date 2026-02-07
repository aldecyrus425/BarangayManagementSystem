using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class ResidentDTO
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
        public string Contact { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public string BloodType { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }

        public UserDTO User { get; set; }
        public int UserId { get; set; }
    }

    public class AddResidentDTO
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; } = "";
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public string BloodType { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateResidentDTO
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; } = "";
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public string BloodType { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
    }
}
