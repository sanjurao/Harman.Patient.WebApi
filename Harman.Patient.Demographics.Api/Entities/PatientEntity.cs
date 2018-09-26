using System;
using System.Collections.Generic;
using System.Text;

namespace Harman.Data.Entity.Entities
{
    public class PatientEntity
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string GenderType { get { return Enum.GetName(typeof(CodeTable), Gender); } }
        public List<TelephoneEntity> TelePhones { get; set; }
    }
}
