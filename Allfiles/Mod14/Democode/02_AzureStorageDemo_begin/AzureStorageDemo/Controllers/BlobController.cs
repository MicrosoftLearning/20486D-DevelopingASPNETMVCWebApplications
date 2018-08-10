using System;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.AspNetCore.Http;

namespace AzureStorageDemo.Controllers
{
    public class BlobController : Controller
    {

        string connectionString = "CONNECTION_STRING";
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile photo)
        {
           
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
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

            ViewBag.BlobContainerName = container.Name;
            CloudBlockBlob blob = container.GetBlockBlobReference(photo.FileName);
            ViewBag.BlobName = blob.Name;
            await blob.UploadFromStreamAsync(photo.OpenReadStream());
            ViewBag.UploadSize = blob.Properties.Length;

            TempData["LatestImage"] = blob.Uri.ToString();
            return RedirectToAction("LatestImage");
        }


        public ActionResult LatestImage()
        {
            var latestImage = string.Empty;
            if (TempData["LatestImage"] != null)
            {
                ViewBag.LatestImage = Convert.ToString(TempData["LatestImage"]);
            }

            return View();
        }

    }

    

}