using System;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using AzureStorageDemo.Models;
using AzureStorageDemo.Data;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureStorageDemo.Controllers
{
    public class BlobController : Controller
    {
        private IConfiguration _configuration;
        private string _connectionString;
        private PhotoContext _dbContext;

        public BlobController(IConfiguration configuration, PhotoContext dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("AzureStorageConnectionString-1");
        }

        [HttpGet]
        public IActionResult CreateImage()
        {
            return View();
        }


        [HttpPost, ActionName("CreateImage")]
        public async Task<IActionResult> CreateImageAsync(Photo photo)
        {
            if (ModelState.IsValid)
            {
                photo.CreatedDate = DateTime.Today;
                if (photo.PhotoAvatar != null && photo.PhotoAvatar.Length > 0)
                {
                    photo.ImageMimeType = photo.PhotoAvatar.ContentType;
                    photo.ImageName = Path.GetFileName(photo.PhotoAvatar.FileName);
                    using (var memoryStream = new MemoryStream())
                    {
                        photo.PhotoAvatar.CopyTo(memoryStream);
                        photo.PhotoFile = memoryStream.ToArray();
                    }
                    await UploadAsync(photo.PhotoAvatar);
                    _dbContext.Add(photo);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View(photo);
            }
            return View(photo);
        }

        public async Task UploadAsync(IFormFile photo)
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
                });
            }
            CloudBlockBlob blob = container.GetBlockBlobReference(Path.GetFileName(photo.FileName));
            await blob.UploadFromStreamAsync(photo.OpenReadStream());
        }
    }
}