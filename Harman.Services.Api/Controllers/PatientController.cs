using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Harman.Services.Api.Model;
using Harman.Business;
using Harman.Data.Entity.Entities;
using Harman.Data.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Resources;
using Microsoft.AspNetCore.Cors;

namespace Harman.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("patients")]
    //[ApiController]
    public class PatientController : Controller
    {
        private readonly IPatient _patient;
        private readonly IMapper _map;
        public PatientController(IPatient patient, IMapper mapper)
        {
            _patient = patient;
            _map = mapper;
        }
        [HttpGet]
        public IEnumerable<PatientEntity> GetPatientsDetails()
        {
            var response = _patient.GetPatients();
            return response;
        }

        // POST api/Customers
        // Dependency Injection: using [FromService] is another way of requesting services from DI
        
         [HttpPost]
         public async Task<ObjectResult> PostAsync([FromBody]PatientModel patientModelObj)
         {
             if (patientModelObj == null || !patientModelObj.ValidatePatientModel())
             {
                 return BadRequest(BuildStringFromResource("First Name, SurName & Genders are Mandatory"));
             }

             var patientEntity = _map.Map<PatientModel, PatientEntity>(patientModelObj, new PatientEntity());
            
             var patientDataActionResult = await _patient.AddPatients(patientEntity);

             if (!patientDataActionResult.IsSuccess)
             {
                 return StatusCode(StatusCodes.Status500InternalServerError, BuildStringFromResource("UnexpectedServerError"));
             }
             return Ok(patientDataActionResult.PatientEntity);
         }

        private string BuildStringFromResource(string resourceStringName, params object[] replacements)
        {
            return string.Format(resourceStringName, replacements);
        }
    }
}