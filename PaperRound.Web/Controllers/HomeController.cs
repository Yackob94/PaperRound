using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PaperRound.Core;
using PaperRound.Core.Models;
using PaperRound.Web.Models;

namespace PaperRound.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeliveryFactory _deliveryFactory;

        public HomeController(DeliveryFactory deliveryFactory)
        {
            _deliveryFactory = deliveryFactory;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadSpecification(HttpPostedFileBase specificationFile)
        {

            if (specificationFile == null)
                return View("Index", new Report { Message = "No file was selected" });

            var uploadDirectory = Path.Combine(Environment.CurrentDirectory, ConfigurationManager.AppSettings["SpecificationDirectory"]);

            if (!Directory.Exists(uploadDirectory))
                Directory.CreateDirectory(uploadDirectory);

            var fileName = $"{Guid.NewGuid()}.txt";
            var filePath = Path.Combine(uploadDirectory, fileName);

            specificationFile.SaveAs(filePath);

            var model = new Report();

            var fileResult = new StreetSpecificationParser().ParseStreetSpecification(filePath);

            System.IO.File.Delete(filePath);

            if (!fileResult.Valid)
            {
                model.Valid = false;
                model.Message = fileResult.Message;

                return View("Index", model);
            }

            if (!fileResult.StreetSpecification.Valid)
            {
                model.Valid = false;
                model.Message = fileResult.StreetSpecification.Message;
                return View("Index", model);
            }

            model.Valid = true;
            model.TotalHouses = fileResult.StreetSpecification.Houses.Count;
            model.LeftHouses = fileResult.StreetSpecification.LeftHouses.Count;
            model.RightHouses = fileResult.StreetSpecification.RightHouses.Count;


            model.ClockwiseDeliveryMethod =
                _deliveryFactory.CreateDeliveryMethod<ClockwiseDeliveryMethod>(fileResult.StreetSpecification);
            model.AlternateDeliveryMethod =
             _deliveryFactory.CreateDeliveryMethod<AlternateDeliveryMethod>(fileResult.StreetSpecification);

            return View("Index", model);
        }
    }
}