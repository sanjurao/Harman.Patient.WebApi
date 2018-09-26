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
    public class PatientRepositoryfake : IPatientRepository
    {
        //private readonly HealthCareMainDBContext _entityDBContext;
        private readonly PatientDataActionResult _failedPatientDataActionResult = new PatientDataActionResult(false, null);
        private readonly PatientEntity _patientEntity;
        private readonly List<PatientEntity> _ListpatientEntity;
        //private readonly IMapper _map;

        public PatientRepositoryfake(HealthCareMainDBContext dbContext)
        {
            // _entityDBContext = dbContext;
            //_map = mapper;
            _patientEntity = new PatientEntity();
            _ListpatientEntity = new List<PatientEntity>();

        }
        public IEnumerable<PatientEntity> GetPatients()
        {
            var res = InputData(3);
            return res;

        }

        public async Task<PatientDataActionResult> AddPatients(PatientEntity patientModelObj)
        {

            try
            {
                var newtblPatient = new AddMapper(patientModelObj).MapEntity();                

                if (patientModelObj == null)
                {
                    return _failedPatientDataActionResult;
                }

                return new PatientDataActionResult(true, (new TblPatient()));
            }
            catch
            {
                return _failedPatientDataActionResult;
            }

        }
        

        private List<PatientEntity> InputData(int rec)
        {
            List<PatientEntity> ps = new List<PatientEntity>();
            for (int i = 0; i < rec; i++)
            {
                TelephoneEntity t = new TelephoneEntity { CodeTableId = 1, Number = "1213123123" };
                List<TelephoneEntity> tlist = new List<TelephoneEntity>();
                tlist.Add(t);
                PatientEntity patientEntity = new PatientEntity { FirstName = "asdas", Gender = 1, Dob = DateTime.Now.Date, SurName = "zsdsad", TelePhones = tlist };                
                ps.Add(patientEntity);
            }
            return ps;
        }
    }

}
