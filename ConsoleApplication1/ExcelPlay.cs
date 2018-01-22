using AssessmentTest;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ExcelPlay
    {
        public void readExcel()
        {
            var package = new ExcelPackage(new FileInfo("sample.xlsx"));
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            for (int i = workSheet.Dimension.Start.Column;i <= workSheet.Dimension.End.Column;
                    i++)
            {
                for (int j = workSheet.Dimension.Start.Row;
                        j <= workSheet.Dimension.End.Row;
                        j++)
                {
                    object cellValue = workSheet.Cells[i, j].Value;
                }
            }

        }

        public void writeExcel()
        {
            // Set the file name and get the output directory
            var fileName = "Example-CRM-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = "c:\\test.xlsx";
            // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sales list - " + DateTime.Now.ToShortDateString());

                // --------- Data and styling goes here -------------- //
                // Add some formatting to the worksheet
                worksheet.TabColor = Color.Blue;
                worksheet.DefaultRowHeight = 12;
                worksheet.HeaderFooter.FirstFooter.LeftAlignedText = string.Format("Generated: {0}", DateTime.Now.ToShortDateString());
                worksheet.Row(1).Height = 20;
                worksheet.Row(2).Height = 18;

                //Ok now format the first row of the heade, but only the first two columns;
                using (var range = worksheet.Cells[1, 1, 1, 2])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Black);
                    range.Style.Font.Color.SetColor(Color.WhiteSmoke);
                    range.Style.ShrinkToFit = false;
                }
                // Keep track of the row that we're on, but start with four to skip the header
                int rowNumber = 4;

                var companies = new List<Customer>()
                {
                    new Customer() {  Name = "Vamsi" , Address = "Herndon" , CustomerType = "C" },
                    new Customer() {  Name = "Vamsi" , Address = "Herndon" , CustomerType = "C" },
                    new Customer() {  Name = "Vamsi" , Address = "Herndon" , CustomerType = "C" }
                };

                // Loop through all the companies and add their vehicles
                foreach (var company in companies)
                {
                    worksheet.Cells[rowNumber, 1].Value = company.Name;
                    worksheet.Cells[rowNumber, 2].Value = company.Address;
                    worksheet.Cells[rowNumber, 7].Value = company.CustomerType;

                    //Ok now format the company row
                    using (var range = worksheet.Cells[rowNumber, 1, rowNumber, 7])
                    {
                        range.Style.Font.Bold = false;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);
                        range.Style.Font.Color.SetColor(Color.Black);
                        range.Style.ShrinkToFit = false;
                    }

                    // Add one row and start add the vehicles               
                    rowNumber++;

                    //foreach (var vehicle in rankedCompanyVehicleFleet.Vehicles)
                    //{
                    //    worksheet.Cells[rowNumber, 2].Value = vehicle.RegistrationNumber;
                    //    worksheet.Cells[rowNumber, 3].Value = vehicle.Brand;
                    //}
                }
                // Fit the columns according to its content
                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();

                // Set some document properties
                package.Workbook.Properties.Title = "Sales list";
                package.Workbook.Properties.Author = "Gustaf Lindqvist @ Ted & Gustaf";
                package.Workbook.Properties.Company = "Ted & Gustaf";

                // save our new workbook and we are done!
                package.Save();


            }

        }

    }
}
