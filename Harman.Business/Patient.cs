using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Harman.Data.Entity.DataAccess;
using Harman.Data.Entity.Entities;
using Harman.Data.Entity.Models;

namespace Harman.Business
{
    public class Patient : IPatient
    {
        private readonly IPatientRepository _patientRepository;
        public Patient(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<PatientDataActionResult> AddPatients(PatientEntity patientModelObj)
        {
            if (patientModelObj == null)
            {
                throw new ArgumentNullException();
            }
            return _patientRepository.AddPatients(patientModelObj);
        }

        public IEnumerable<PatientEntity> GetPatients()
        {
            return _patientRepository.GetPatients();
        }        
    }
}
