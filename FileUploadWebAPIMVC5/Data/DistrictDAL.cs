using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileUploadWebAPIMVC5.Models;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Ionic.Zip;

namespace FileUploadWebAPIMVC5.Data
{
    public class DistrictDAL : IDistrict
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public string getDistricts()
        {
            List<string> listFileNames = null;
            IEnumerable<District> ienum = null;
            string filePath = string.Empty;
            using (IDbConnection connection = _db)
            {
                const string query = " SELECT ZIP_ID,ZIP5_CD,CONGRESSIONAL_DISTRICT,STATE FROM TESTDB.DBO.DISTRICT ";
                ienum = connection.Query<District>(query,null,null,false,null,null);
                listFileNames = new List<string>();
                using (var fileStream = File.Create(Path.Combine(Path.GetTempPath(), string.Format("{0}_{1}.csv", "myfile1", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")))))
                {
                    listFileNames.Add(fileStream.Name);
                    DateTime dt1 = DateTime.Now;
                    // CsvHelper.ToCsv<District>(ienum, fileStream);
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;
                    var timest = ts.TotalMinutes;
                }
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFiles(listFileNames);
                    filePath = Path.GetTempPath() + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".zip";
                    zip.Save(filePath);
                    listFileNames.ForEach(x => System.IO.File.Delete(x.ToString()));
                }

            }
            return filePath;
        }
    }
    public interface IDistrict
    {
        string getDistricts();
    }
}