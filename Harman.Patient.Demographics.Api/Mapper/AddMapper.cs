using Harman.Data.Entity.Entities;
using Harman.Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harman.Data.Entity.Mapper
{
    public class AddMapper
    {
        private readonly PatientEntity _patient;
        public AddMapper(PatientEntity patient)
        {
            _patient = patient;
        }
        public TblPatient MapEntity()
        {
            var Telephones = new List<TblTelephone>();
            foreach (var item in _patient.TelePhones)
            {
                var telephone = new TblTelephone();
                telephone.Number = item.Number;
                telephone.CodeTableId = item.CodeTableId;
                Telephones.Add(telephone);
            }
            return new TblPatient()
            {
                FirstName = _patient.FirstName,
                SurName = _patient.SurName,
                Dob = _patient.Dob,
                Gender = _patient.Gender,
                TblTelephone = Telephones
            };
        }
    }

}
