using Harman.Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harman.Data.Entity.Entities
{
    public class PatientDataActionResult
    {
        public PatientDataActionResult(bool isSuccess, TblPatient patientEntity)
        {
            IsSuccess = isSuccess;
            PatientEntity = patientEntity;
        }

        public bool IsSuccess { get; }

        public TblPatient PatientEntity { get; private set; }
    }
}
