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
           
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("myimagecontainer");

            if (await container.CreateIfNotExistsAsync())
            {
                await container.SetPermissionsAsync(
                    new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    }
                    );
            }

           
            CloudBlockBlob blob = container.GetBlockBlobReference(photo.FileName);
           
            await blob.UploadFromStreamAsync(photo.OpenReadStream());
           

            TempData["ImageURL"] = blob.Uri.ToString();
            return View("LatestImage");
           
        }


    }

    

}