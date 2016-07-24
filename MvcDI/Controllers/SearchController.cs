using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDI.Controllers
{
    //this need to be removed and replaced by real implementation
    public class SiteFilter
    {
        public string searchBoxInput { get; set; }
    }
    //this need to be removed and replaced by real implementation
    public class SearchData
    {
        public string searchId { get; set; }
        public string text { get; set; }
        public string description { get; set; }
    }
    //this need to be removed and replaced by real implementation
    public class SearchController : Controller
    {
        //this need to be removed and replaced by real implementation
        private List<Controllers.SearchData> getSearchFakeData()
        {
            return new List<Controllers.SearchData>()
            {
                new SearchData()
                {
                    searchId = "100", description = "100 description" , text = "100 text"
                },
                new SearchData()
                {
                    searchId = "101", description = "101 description" , text = "101 text"
                },
                new SearchData()
                {
                    searchId = "102", description = "102 description" , text = "102 text"
                }
            };
        }
        // GET: Search
        public PartialViewResult Index(SiteFilter filter)
        {
            string strSearch;
            List<SearchData> lst = null;
            try
            {
                strSearch = filter.searchBoxInput.ToString();
            }
            catch (Exception ex)
            {
                strSearch = "SEARCH";
                throw;
            }

            ViewData["filter"] = strSearch;
            if (filter.searchBoxInput != "SEARCH")
            {
                System.Threading.Thread.Sleep(10000);
                lst = getSearchFakeData();
            }
            return PartialView("~/Views/Shared/_SearchData.cshtml", lst);
        }
    }
}