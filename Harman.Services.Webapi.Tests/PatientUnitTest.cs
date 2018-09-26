using AutoMapper;
using Harman.Business;
using Harman.Data.Entity.DataAccess;
using Harman.Data.Entity.Entities;
using Harman.Data.Entity.Models;
using Harman.Services.Api.Controllers;
using Harman.Services.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Harman.Services.Webapi.Tests
{
    public class PatientUnitTest
    {
        private readonly IServiceProvider _serviceProvider;

        private PatientController _controller;

        public PatientUnitTest()
        {
            var services = new ServiceCollection();
            services.AddScoped(_ => new HealthCareMainDBContext());
            services.AddScoped<IPatientRepository, PatientRepositoryfake>();
            services.AddScoped<IPatient, Patient>();
            services.AddAutoMapper();
            _serviceProvider = services.BuildServiceProvider();

            _controller = new PatientController(_serviceProvider.GetRequiredService<IPatient>(), _serviceProvider.GetRequiredService<IMapper>());
            _controller.ControllerContext.HttpContext = new DefaultHttpContext()
            {
                RequestServices = _serviceProvider
            };
        }

        [Fact]
        public void Get_Patients_Details_200Ok()
        {
            var result = _controller.GetPatientsDetails();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PostAsyncWithNullPatientsInfoReturnsBadRequest()
        {
            var result = await _controller.PostAsync(null);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);

        }

        [Fact]
        public async Task PostAsyncWithValidPatientInfoAddsPatientsAndReturns200OK()       {


            List<TelephoneModel> tlist = new List<TelephoneModel>();
            for (int i = 2; i <= 4; i++)
            {
                TelephoneModel t = new TelephoneModel { CodeTableId = i, Number = $"12131231_{i}" };
                tlist.Add(t);
            }
            PatientModel patientEntity = new PatientModel { FirstName = "asdas", Gender = 1, Dob = DateTime.Now.Date, SurName = "zsdsad", Telephones = tlist };

            var result = await _controller.PostAsync(patientEntity);

            // assert status code
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);          
        }
    }

}
