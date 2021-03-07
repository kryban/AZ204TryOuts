using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TelemetryShowImageFromBlob001.Models;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace TelemetryShowImageFromBlob001.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        string blobConnstr;
        string containername = "bansblob001";
        string blobname = "bansblobfile001";
        TelemetryClient telemetryClient;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {            
            _logger = logger;
            configuration = config;
            telemetryClient = new TelemetryClient(new TelemetryConfiguration());
        }

        public IActionResult Index()
        {
            // hier wordt een try out gedaan hoe de settings in een web app aamgeroepen kunnen worden
            // Dus via de blob client wordt een plaatje getoond (blob)
            // Zowel container- als blob namen zijn hetzelfde, alleen de storageaccount naam is anders en het plaatje zelf (wel dezelfde naam).
            // in debug wordt storage account "bansstorage001", terwijl in de webapp "bansconfiguredstorage001" aangewezen is
            // dat betekent dat tijdens debug een andere plaatje getoond moet worden dan wanneer het gedeployed is.

            // id dit project is de code instrumented om metingen te kunnen doen

            // Om azure op te tuigen voer je de commands uit AZ-commands uit (let op dat je image files in de juiste path zet)

            blobConnstr = configuration["StorageConnectionString"];
            BlobClient client = new BlobClient(blobConnstr, containername, blobname);

            BlobImage img = new BlobImage
            {
                BlobImageName = client.Name,
                BlobImageUrl = client.Uri.AbsoluteUri
            };

            telemetryClient.TrackEvent("BansFooEvent");

            return View(img);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BansAbout()
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
