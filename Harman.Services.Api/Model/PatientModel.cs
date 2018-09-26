using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Services.Api.Model
{
    public class PatientModel 
    {
        public int PatientId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sur Name is Required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Gender is Required")]        
        public int Gender { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Dob { get; set; }
        public ICollection<TelephoneModel> Telephones { get; set; }

        public bool ValidatePatientModel()
        {
            return !string.IsNullOrEmpty(FirstName)
                && !string.IsNullOrEmpty(SurName)
                && Gender != -1;
        }
    }
}
