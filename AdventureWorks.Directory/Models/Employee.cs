using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Directory.Models
{
    public class Employee
    {
        public string Employee_Id { get; set; }
        public string Suffix { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Full_Name { get; set; }
        public string Job_Title { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_Code { get; set; }
        public string Country { get; set; }
        public string Department_Id { get; set; }
        public string Department { get; set; }
        public string Phone_Number { get; set; }
        public string Extension { get; set; }
        public string Phone_Type { get; set; }
        public string EMail { get; set; }

    }

    public class ListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}