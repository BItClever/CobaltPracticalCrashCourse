using CobaltPracticalCrashCourse.Infrastructure;
using CobaltPracticalCrashCourse.Models;
using CobaltPracticalCrashCourse.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CobaltPracticalCrashCourse.Controllers
{
    public class HomeController : Controller
    {
        private IExplorerService _explorerService;
        public HomeController(IExplorerService explorerService)
        {
            _explorerService = explorerService;
        }

        public ActionResult Explorer(string drive, string path)
        {
            var fullPath = string.Concat(drive, ":\\", path);
            if (System.IO.File.Exists(fullPath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(fullPath);
                return File(fileBytes, "application/downloads");
            }
            else if (Directory.Exists(fullPath))
            {
                var dirListModel = _explorerService.MapDirs(fullPath);
                var fileListModel = _explorerService.MapFiles(fullPath);
                var explorerModel = new ExplorerViewModel(dirListModel, fileListModel);

                //For using browser ability to correctly browsing the folders,
                //Every path needs to end with slash
                if (fullPath.Last() != '/' && fullPath.Last() != '\\')
                { explorerModel.URL = "/Explorer/" + fullPath + "/"; }
                else
                { explorerModel.URL = "/Explorer/" + fullPath; }

                UriBuilder uriBuilder = new UriBuilder
                { Path = HttpContext.Request.Path.ToString() };

                //Show the current directory name using page URL.
                explorerModel.FolderName = WebUtility.UrlDecode(uriBuilder.Uri.Segments.Last());

                //Making a URL to going up one level. 
                Uri uri = new Uri(uriBuilder.Uri.AbsoluteUri.Remove
                                    (uriBuilder.Uri.AbsoluteUri.Length -
                                     uriBuilder.Uri.Segments.Last().Length));

                explorerModel.ParentFolderName = uri.AbsolutePath;

                return View(explorerModel);
            }
            else
            {
                return Content(fullPath + " is not a valid file or directory.");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
    }
}