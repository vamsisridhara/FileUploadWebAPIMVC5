using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FileUploadWebAPIMVC5.Models
{
    public static class FetchData
    {
        public static List<Manager> getmanagers()
        {
            return new List<Manager>() {
                new Manager()
                {
                    ManagerID = 100 ,
                    ManagerName = "Adam Whitemer" ,
                    Location = "Bethelhem, PA" ,
                    DeptName = Department.Accounts ,
                    Employees = new List<Employees>()
                    {
                        new Employees()
                            {
                                EmployeeID =1 ,
                                ManagerID = 100,
                                EmployeeName = "Adam Whitemer",
                                DeptList = new List<Department>() {  Department.Accounts , Department.Parts},
                                Location = "Bethelhem, PA"
                            },
                        new Employees()
                            {
                                EmployeeID =2 ,
                                ManagerID = 100,
                                EmployeeName = "Adam Whitemer1",
                                DeptList = new List<Department>() {  Department.Sales , Department.Parts},
                                Location = "Bethelhem, PA"
                            }
                    }
                },
                 new Manager()
                {
                    ManagerID = 101 ,
                    ManagerName = "Administrator" ,
                    Location = "NewCastle, DE" ,
                    DeptName = Department.Parts ,
                    Employees = new List<Employees>()
                    {
                        new Employees()
                            {
                                EmployeeID =2 ,
                                ManagerID = 101,
                                EmployeeName = "Administrator",
                                DeptList = new List<Department>() {  Department.Sales, Department.Parts},
                                Location = "Bethelhem, PA"
                            },
                        new Employees()
                            {
                                EmployeeID =22 ,
                                 ManagerID = 101,
                                EmployeeName = "Adam Whitemer1",
                                DeptList = new List<Department>() {  Department.Accounts , Department.Parts},
                                Location = "Bethelhem, PA"
                            }
                    }
                },
                  new Manager()
                {
                    ManagerID = 102 ,
                    ManagerName = "Ann Conoor" ,
                    Location = "Herndon, VA" ,
                    DeptName = Department.Sales ,
                    Employees = new List<Employees>()
                    {
                        new Employees()
                            {
                                EmployeeID =23 ,
                                ManagerID = 102,
                                EmployeeName = "Administrator",
                                DeptList = new List<Department>() {  Department.Sales, Department.Parts},
                                Location = "Bethelhem, PA"
                            },
                        new Employees()
                            {
                                EmployeeID =24 ,
                                 ManagerID = 102,
                                EmployeeName = "Adam Whitemer1",
                                DeptList = new List<Department>() {  Department.Accounts , Department.Parts},
                                Location = "Bethelhem, PA"
                            }
                    }
                }
            };
        }


    }
    public class Manager
    {
        public string ManagerName { get; set; }
        public int ManagerID { get; set; }

        public Department DeptName { get; set; }
        public string Location { get; set; }
        public List<Employees> Employees { get; set; }
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Department
    {
        [EnumMember(Value = "Accounts")]
        Accounts,
        [EnumMember(Value = "Parts")]
        Parts,
        [EnumMember(Value = "Sales")]
        Sales
    }
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public List<Department> DeptList { get; set; }
        public string Location { get; set; }
        public int ManagerID { get; set; }
    }
}