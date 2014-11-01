using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileUploadWebAPIMVC5.Models;
namespace FileUploadWebAPIMVC5.Data
{
    public class DistrictBL
    {
        public static string getDistricts()
        {
            IDistrict idis = new DistrictDAL();
            return idis.getDistricts();
        }
    }
}