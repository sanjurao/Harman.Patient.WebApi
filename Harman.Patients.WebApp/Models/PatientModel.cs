using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Harman.Patients.WebApp.Models
{
    public class PatientModel
    {
        public PatientModel()
        {
            Contacts = new List<ContactModel>();
            Contacts.Add(new ContactModel());

        }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Forenames { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Surname { get; set; }

        [DataType(DataType.DateTime)]       
        public DateTime DOB { get; set; }

        [Required]
        public byte? Gender { get; set; }

        public IList<ContactModel> Contacts { get; set; }

    }

    public class ContactModel
    {
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        public string MobileNumber { get; set; }
    }

    public enum Gender: byte
    {
        Male,
        Female,
        Others
    }
}