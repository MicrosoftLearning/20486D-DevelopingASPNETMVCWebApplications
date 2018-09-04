using System;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
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
            _connectionString = _configuration.GetConnectionString("{your_storage_account_name}_AzureStorageConnectionString");
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile photo)
        {

            return View("LatestImage");
        }


    }



}