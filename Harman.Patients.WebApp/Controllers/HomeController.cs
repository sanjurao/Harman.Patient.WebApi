using Harman.Patients.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Harman.Patients.WebApp.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<PatientModel> patients = null;

            using (var client = new HttpClient ())
            {
                client.BaseAddress = new Uri("http://localhost:64189/api/");
                //HTTP GET
                var responseTask = client.GetAsync("patient");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PatientModel>>();                    
                    readTask.Wait();

                    patients = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    patients = Enumerable.Empty<PatientModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(patients);

        }

        [HttpGet]
        public async Task<ActionResult> GetPatientDetailsAsync()
        {
            PatientModel pm = new PatientModel();

            var msg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:62463/api/patients");
            var client = new HttpClient();
            var res = await client.SendAsync(msg);
             
            string content = null;
            if (res.Content != null)
            {
                content = await res.Content.ReadAsStringAsync();
                //pm = content as List<PatientModel>();
            }
            else
            {

            }

            if (!res.IsSuccessStatusCode)
            {
                var error = string.Format("Something went wrong :-( {0}", content);
                throw new Exception(error);
            }

            return View(pm);
        }

        [HttpPost]
        public async Task<ActionResult> AddPatientAsync(PatientModel pm)
        {
            
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64189/api/student");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<PatientModel>("patient", pm);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(pm);
            }
            return View(pm);
        }

    }
}