using FileUploadWebAPIMVC5.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class WebValidationController : Controller
    {
        // GET: WebValidation
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public JsonResult postrules(WebValidationModel inputModel)
        {
            var businessRules = this.processRules(inputModel);
            return Json(new
            {
                Data = "success",
                failRules = businessRules.Item1,
                passRules = businessRules.Item2
            }, JsonRequestBehavior.AllowGet);
        }
        private Tuple<List<String>, List<string>> processRules(WebValidationModel inputModel)
        {
            List<String> errors = new List<String>();
            List<String> passvalidation = new List<String>();
            var rules = ReadBusinessRules.loadData();
            //	Item weight cannot exceed MaxWeight field
            var query = rules.Where(x => x.Name == inputModel.description).Select(x => x).FirstOrDefault();
            if (inputModel.weight > query.MaxWeight)
            {
                errors.Add("Item weight cannot exceed MaxWeight field");
            }
            else
            {
                passvalidation.Add("Item weight validation passed");
            }
            // If dimensions are provided, item volume must be more than MinVolume but less than MaxVolume
            if (inputModel.width > 0 && inputModel.height > 0 && inputModel.length > 0)
            {
                var volume = inputModel.width * inputModel.height * inputModel.length;
                if (volume > query.MinVolume && volume < query.MaxVolume)
                {
                    passvalidation.Add("Item volume validation passed");
                }
                else
                {
                    errors.Add("item volume must be more than MinVolume but less than MaxVolume");
                }
            }
            // filterby fragile
            if (query.AcceptsFragile == inputModel.isFragile)
            {
                passvalidation.Add("item is fragile");
            }
            else
            {
                errors.Add("item is not fragile");
            }
            return new Tuple<List<string>, List<string>>(errors, passvalidation);

        }
    }
}