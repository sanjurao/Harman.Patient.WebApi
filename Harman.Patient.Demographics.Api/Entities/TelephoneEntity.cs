using System;
using System.Collections.Generic;
using System.Text;

namespace Harman.Data.Entity.Entities
{
    public class TelephoneEntity
    {
        public int TelephoneId { get; set; }
        public string Number { get; set; }
        public int? CodeTableId { get; set; }
        public int? PatientId { get; set; }
        public string Type { get { return Enum.GetName(typeof(CodeTable), CodeTableId); } }

    }
}
