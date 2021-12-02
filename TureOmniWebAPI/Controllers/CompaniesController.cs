using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using TureOmniWebAPI.Models;
using System.Text.Json;

namespace TureOmniWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        Deserialized deserialized;
        public CompaniesController()
        {
            deserialized  = new Deserialized();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyData>> GetCompanies()
        {
            var companies = deserialized.Deserialize();

            return companies;
        }
    }
}
