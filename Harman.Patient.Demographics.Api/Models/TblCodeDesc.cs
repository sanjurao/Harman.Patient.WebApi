using System;
using System.Collections.Generic;

namespace Harman.Data.Entity.Models
{
    public partial class CodeTable
    {
        public int CodeTableId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Updatedate { get; set; }
    }
}
