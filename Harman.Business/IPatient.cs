using Harman.Data.Entity.Entities;
using Harman.Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Harman.Business
{
    public interface IPatient
    {
        IEnumerable<PatientEntity> GetPatients();

        Task<PatientDataActionResult> AddPatients(PatientEntity patientModelObj);

    }
}
