using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace FileUploadWebAPIMVC5.Models
{
    public class WebValidationModel
    {
        [Display(Name = "Name")]
        [Required]
        public string description { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public double weight { get; set; }

        [Display(Name = "Fragile")]
        public bool isFragile { get; set; }

        [Display(Name = "Length")]
        public int length { get; set; }

        [Display(Name = "Width")]
        public int width { get; set; }

        [Display(Name = "Height")]
        public int height { get; set; }

    }
    public class BusinessRules
    {
        public string Name { get; set; }
        public double MaxWeight { get; set; }
        public int MinVolume { get; set; }
        public int MaxVolume { get; set; }
        public bool AcceptsFragile { get; set; }
    }
    public class ReadBusinessRules
    {
        public static List<BusinessRules> loadData()
        {
            string businessRulesCsv = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath,
                                        "App_Data", "BusinessRules.csv");
            using (CsvReader csv = new CsvReader(new StreamReader(businessRulesCsv), true))
            {
                var records = csv.GetRecords<BusinessRules>().ToList<BusinessRules>();
                return records;
            }
        }

    }
}