using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using System.Configuration;
using System.Web.Configuration;
using System.Net;
using System.Runtime.Caching;
using System.IO;

namespace AdventureWorks.Directory.Models
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        void Invalidate(string key);
    }

    public class DefaultCacheProvider : ICacheProvider
    {
        private ObjectCache Cache { get { return MemoryCache.Default; } }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return (Cache[key] != null);
        }

        public void Invalidate(string key)
        {
            Cache.Remove(key);
        }
    }

    public static class Employees
    {
        private static ObjectCache Cache { get { return MemoryCache.Default; } }


        public static IList<Employee> All
        {
            get
            {
                if (Cache["employees"] == null)
                {
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(720);
                    Cache.Add(new CacheItem("employees", GetEmployeeList()), policy);
                }
                return Cache["employees"] as IList<Employee>;
            }
        }

        static void Invalidate(string key)
        {
            Cache.Remove(key);
        }



        static IList GetEmployeeList()
        {

            var dt = GetSQLServerItems("select * from HumanResources.vEmployeeDirectory");
            List<Employee> employees = (from DataRow row in dt.Rows
                                        select new Employee
                                        {
                                            Employee_Id = row["BusinessEntityID"].ToString() ?? string.Empty,
                                            Suffix = row["Suffix"].ToString() ?? string.Empty,
                                            First_Name = row["FirstName"].ToString() ?? string.Empty,
                                            Last_Name = row["LastName"].ToString() ?? string.Empty,
                                            Middle_Name = row["MiddleName"].ToString() ?? string.Empty,
                                            Full_Name = (row["FirstName"].ToString() ?? string.Empty) + " " + (row["MiddleName"].ToString() ?? string.Empty) + " " + (row["LastName"].ToString() ?? string.Empty),
                                            Job_Title = row["JobTitle"].ToString() ?? string.Empty,
                                            Address1 = row["AddressLine1"].ToString() ?? string.Empty,
                                            Address2 = row["AddressLine2"].ToString() ?? string.Empty,
                                            City = row["City"].ToString() ?? string.Empty,
                                            State = row["StateProvinceName"].ToString() ?? string.Empty,
                                            Postal_Code = row["PostalCode"].ToString() ?? string.Empty,
                                            Country = row["CountryRegionName"].ToString() ?? string.Empty,
                                            Department_Id = row["DepartmentID"].ToString() ?? string.Empty,
                                            Department = row["DepartmentName"].ToString() ?? string.Empty,
                                            Phone_Number = row["PhoneNumber"].ToString() ?? string.Empty,
                                            Phone_Type = row["PhoneNumberType"].ToString() ?? string.Empty,
                                            EMail = row["EmailAddress"].ToString() ?? string.Empty

                                        }).ToList();
            return employees;


        }

        static DataTable GetSQLServerItems(string query)
        {
            Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("~");
            string connectionString = webConfig.ConnectionStrings.ConnectionStrings["AdventureWorks"].ConnectionString;
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    //connection.ConnectionString = connectionString;
                    command.Connection = connection;
                    command.CommandText = query;
                    table.Load(command.ExecuteReader());
                    connection.Close();
                }
                table.Locale = CultureInfo.CurrentCulture;
                return table;
            }
            finally
            {
                table.Dispose();
            }

        }

        public static byte[] GetImage(int id)
        {
            //System.Drawing.Bitmap bmp = null;
            byte[] picData = null;
            Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("~");
            string connectionString = webConfig.ConnectionStrings.ConnectionStrings["AdventureWorks"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT Photo FROM HumanResources.EmployeePhoto WHERE BusinessEntityID =" + id, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        picData = reader["Photo"] as byte[] ?? null;

                        //if (picData != null)
                        //{
                        //    using (MemoryStream ms = new MemoryStream(picData))
                        //    {
                        //        // Load the image from the memory stream. How you do it depends
                        //        // on whether you're using Windows Forms or WPF.
                        //        // For Windows Forms you could write:
                        //       bmp = new System.Drawing.Bitmap(ms);
                        //    }
                        //}
                    }
                }
            }
            return picData;

        }

    }
}