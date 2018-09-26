using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Harman.Data.Entity.Entities;
using Harman.Data.Entity.Mapper;
using Harman.Data.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Harman.Data.Entity.DataAccess
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HealthCareMainDBContext _entityDBContext;
        private readonly PatientDataActionResult _failedPatientDataActionResult = new PatientDataActionResult(false, null);
        //private readonly IMapper _map;

        public PatientRepository(HealthCareMainDBContext dbContext)
        {
            _entityDBContext = dbContext;
            //_map = mapper;


        }
        public IEnumerable<PatientEntity> GetPatients()
        {
            var res = _entityDBContext.TblPatient.Include(t => t.TblTelephone).AsEnumerable();             
            return new GetMapper(res).MapEntity();
        }

        public async Task<PatientDataActionResult> AddPatients(PatientEntity patientModelObj)
        {           
           
           try
            {   
                var newtblPatient = new AddMapper(patientModelObj).MapEntity();

                var added = await _entityDBContext.AddPatientAsync(newtblPatient);

                if (added == null)
                {
                    return _failedPatientDataActionResult;
                }

                return new PatientDataActionResult(true, added);
            }
            catch
            {
                return _failedPatientDataActionResult;
            }

        }


    }
}
