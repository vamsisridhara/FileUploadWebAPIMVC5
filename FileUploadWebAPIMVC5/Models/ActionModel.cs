using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace FileUploadWebAPIMVC5.Models
{
    public enum ActionType
    {
        Create = 1,
        Read = 2,
        Update = 3,
        Delete = 4
    }
    public class ActionModel
    {
        public ActionModel()
        {
            ActionsList = new List<SelectListItem>();
        }

        [Display(Name = "Actions")]
        public int ActionId
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ActionsList
        {
            get;
            set;
        }
    }
}