using System;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AzureStorageDemo.Controllers
{
    public class BlobController : Controller
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public BlobController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("{your_connection_string_name}");
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Upload(IFormFile photo)
        {
            return View("LatestImage");
        }
    }
}