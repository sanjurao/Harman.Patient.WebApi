using System;
using System.Collections.Generic;

namespace Harman.Data.Entity.Models
{
    public partial class TblTelephone
    {
        public int TelephoneId { get; set; }
        public string Number { get; set; }
        public int? CodeTableId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public TblPatient Patient { get; set; }
    }
}
