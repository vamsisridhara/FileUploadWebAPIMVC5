using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadWebAPIMVC5.Models
{
    public class District
    {
        public string ZIP_ID
        {
            get;
            set;
        }
        public string ZIP_CD
        {
            get;
            set;
        }
        public string CONGRESSIONAL_DISTRICT
        {
            get;
            set;
        }
        public string STATE
        {
            get;
            set;
        }
    }
    public class FinalDistrict
    {
        public string ienumer {get;set;}
    }
}