using Harman.Data.Entity.Entities;
using Harman.Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harman.Data.Entity.Mapper
{
    public class GetMapper 
    {
        private readonly IEnumerable<TblPatient> _patients;
        public GetMapper(IEnumerable<TblPatient> patients)
        {
            _patients = patients;
        }

        public virtual IEnumerable<PatientEntity> MapEntity()
        {
            var result = new List<PatientEntity>();
            foreach (var patient in _patients)
            {
                var Telephones = new List<TelephoneEntity>();

                foreach (var item in patient.TblTelephone)
                {
                    var telephone = new TelephoneEntity();
                    telephone.PatientId = item.PatientId;
                    telephone.Number = item.Number;
                    telephone.TelephoneId = item.TelephoneId;
                    telephone.CodeTableId = item.CodeTableId;
                    Telephones.Add(telephone);
                }
                result.Add(new PatientEntity()
                {
                    FirstName = patient.FirstName,
                    SurName = patient.SurName,
                    PatientId = patient.PatientId,
                    Dob = patient.Dob,
                    TelePhones = Telephones,
                    Gender = patient.Gender,
                });

            }
            return result;
        }

        
    }
}
