using System;
using System.Collections.Generic;

namespace Harman.Data.Entity.Models
{
    public partial class TblPatient
    {
        public TblPatient()
        {
            TblTelephone = new HashSet<TblTelephone>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Gender { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<TblTelephone> TblTelephone { get; set; }
    }
}
