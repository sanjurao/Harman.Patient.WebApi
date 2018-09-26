using Harman.Data.Entity.Models;
using System;

namespace Harman.Services.Api.Model
{
    public class TelephoneModel
    {
        public int TelephoneId { get; set; }
        public string Number { get; set; }
        public int? CodeTableId { get; set; }
        public int? PatientId { get; set; }        
    }

}