using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssessmentTest
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int ManagerID { get; set; }
        public string Name { get; set; }
        private Manager _manager=null;
        public Manager Manager
        {
            get
            {
                if (_manager ==null && ManagerID > 0)
                {
                    _manager=new Manager();
                    _manager.Initialize(ManagerID);
                }
                return _manager;
            
            }
        }

        public void Initialize(int employeeID)
        {
            if (employeeID == 1)
            {
                Name = "Fred Jones";
                ManagerID = 1;
                EmployeeID = 100;
            }
            else
            {
                Name = "John The Manager";
                EmployeeID = 500;
            }
        }
        
    
        
    }

    public class Manager:Employee
    {
        public List<string> DepartmentsManaged { get; set; }
        public void Initialize(int employeeID)
        {
            base.Initialize(employeeID);
            DepartmentsManaged = new List<string>();
            if (employeeID == 1)
            {
                DepartmentsManaged.Add("Programming");
                DepartmentsManaged.Add("Hardware");
            }
            else
            {
                DepartmentsManaged.Add("Admin");
            }
        }
    }
}
