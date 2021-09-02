using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PugPdf.Core;
using System.Diagnostics;
using System.Threading.Tasks;
using WebAppPrint.Models;

namespace WebAppPrint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<FileContentResult> Pdf([FromServices] IViewRender view)
        {
            Items items = new();
            var renderer = new HtmlToPdf();
            renderer.PrintOptions.MarginTop = 20d;
            renderer.PrintOptions.MarginLeft = 20d;
            renderer.PrintOptions.MarginRight = 20d;
            renderer.PrintOptions.MarginBottom = 20d;
            renderer.PrintOptions.Header.CenterText = "RELATÓRIO GERAL DE CIDADES";
            renderer.PrintOptions.Header.DisplayLine = true;
            renderer.PrintOptions.Header.Spacing = 4;
            renderer.PrintOptions.Footer.CenterText = "[page] / [topage]";
            renderer.PrintOptions.Footer.FontSize = 7d;
            PdfDocument doc = await renderer
                .RenderHtmlAsPdfAsync(await view.RenderToStringAsync("Home/Pdf", items));
            return new FileContentResult(doc.BinaryData, "application/pdf");
        }

        public IActionResult Example()
        {
            Items items = new();
            return View("Pdf", items);
        }
    }
}
