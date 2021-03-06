using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorageShowImageFromBlob001.Models;
using System.Diagnostics;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace StorageShowImageFromBlob001.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        string blobConnstr;
        string containername = "bansblob001";
        string blobname = "bansblobfile001";


        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration = config;
        }

        public IActionResult Index()
        {
            // hier wordt een try out gedaan hoe de settings in een web app aamgeroepen kunnen worden
            // Dus via de blob client wordt een plaatje getoond (blob)
            // Zowel container- als blob namen zijn hetzelfde, alleen de storageaccount naam is anders en het plaatje zelf (wel dezelfde naam).
            // in debug wordt storage account "bansstorage001", terwijl in de webapp "bansconfiguredstorage001" aangewezen is
            // dat betekent dat tijdens debug een andere plaatje getoond moet worden dan wanneer het gedeployed is.

            /* in AZ: 
             * az storage account create -n bansconfiguredstorage001 -g vs-bandik-we -l westeurope
             * az storage container create -n bansconfiguredblob001 --account-name bansconfiguredstorage001 --public-access blob
             * az storage blob upload --account-name bansconfiguredstorage001 --name bansblobfile001 --container-name bansblob001 --file '.\Desktop\NewFolder\cn3.jpg'
             * az appservice plan create -g vs-bandik-we -n banswebappplan --sku S1
             * az webapp create --plan banswebappplan -n banswebapp001 -g vs-bandik-we --runtime "DOTNETCORE:3.1" 
             */

            blobConnstr = configuration["StorageConnectionString"];
            BlobClient client = new BlobClient(blobConnstr, containername, blobname);

            BlobImage img = new BlobImage
            {
                BlobImageName = client.Name,
                BlobImageUrl = client.Uri.AbsoluteUri
            };

            return View(img);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
