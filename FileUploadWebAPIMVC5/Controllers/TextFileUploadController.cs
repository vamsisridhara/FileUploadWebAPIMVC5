using FileUploadWebAPIMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class TextFileUploadController : Controller
    {
        public ActionResult Index()
        {
            ActionModel model = new ActionModel();
            IEnumerable<ActionType> actionTypes = Enum.GetValues(typeof(ActionType))
                                                       .Cast<ActionType>();
            model.ActionsList = from action in actionTypes
                                select new SelectListItem
                                {
                                    Text = action.ToString(),
                                    Value = ((int)action).ToString()
                                };
            return View(model);
        }
    }
}