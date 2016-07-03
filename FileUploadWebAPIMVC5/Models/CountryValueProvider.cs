using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace FileUploadWebAPIMVC5.Models
{
    public class CountryValueProvider : System.Web.Mvc.IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("country") > -1;
        }
        public ValueProviderResult GetValue(string key)
        {
            if (ContainsPrefix(key))
            {
                return new ValueProviderResult("USA", "USA",
                CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }
    public class CustomValueProviderFactory : System.Web.Mvc.ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new CountryValueProvider();
        }
    }
}