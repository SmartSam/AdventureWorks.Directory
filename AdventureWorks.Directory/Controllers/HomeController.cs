using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using AdventureWorks.Directory.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using DevExpress.Web.Mvc.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.IO;

namespace AdventureWorks.Directory.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            if (!Request.Browser.IsMobileDevice)
                return SearchEmployees();
            else
                return View();
        }

        public ViewResult SearchByName()
        {
            return View();
        }


        public ViewResult AllEmployees()
        {
            var employees = Employees.All.OrderBy(x => x.Last_Name);
            return View("AllEmployees", employees);
        }

        public ViewResult EmployeesByName(string nameCriteria)
        {

            IEnumerable<Employee> employees;
            if (nameCriteria != null && nameCriteria.Length > 0)
            {
                string name = nameCriteria.ToLowerInvariant();
               
                if (name.Contains(' '))
                {
                    string[] names = nameCriteria.Split(' ');
                    employees = Employees.All.Where(employee => (employee.First_Name.ToLower().StartsWith(names[0], true, CultureInfo.InvariantCulture) ||
                                employee.First_Name.ToLower().StartsWith(names[0], true, CultureInfo.InvariantCulture)) &&
                                employee.Last_Name.ToLower().StartsWith(names[1], true, CultureInfo.InvariantCulture)).OrderBy(x => x.Last_Name); ; 
                }
                else if (name.Length == 2)
                    
                    employees = Employees.All.Where(employee => employee.First_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                    employee.Last_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                    ((employee.First_Name.ToLower().StartsWith(name.Substring(0, 1), true, CultureInfo.InvariantCulture) ||
                    employee.First_Name.ToLower().StartsWith(name.Substring(0, 1), true, CultureInfo.InvariantCulture)) &&
                    employee.Last_Name.ToLower().StartsWith(name.Substring(1, 1), true, CultureInfo.InvariantCulture))).OrderBy(x => x.Last_Name);

                else if (name.Length == 3)
                    
                    employees = Employees.All.Where(employee => employee.First_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                                employee.Last_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                                ((employee.First_Name.ToLower().StartsWith(name.Substring(0, 1), true, CultureInfo.InvariantCulture) ||
                                employee.First_Name.ToLower().StartsWith(name.Substring(0, 1), true, CultureInfo.InvariantCulture)) &&
                                employee.Middle_Name.ToLower().StartsWith(name.Substring(1, 1), true, CultureInfo.InvariantCulture) &&
                                employee.Last_Name.ToLower().StartsWith(name.Substring(2, 1), true, CultureInfo.InvariantCulture))).OrderBy(x => x.Last_Name);


                else
                    employees = Employees.All.Where(employee => employee.First_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                                employee.First_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                                employee.Last_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture)).OrderBy(x => x.Last_Name);
            }
            else
            {
                employees = Employees.All.Where(employee => employee.Last_Name.Equals(string.Empty)).OrderBy(x => x.Last_Name); ;
            }
            return View("EmployeesByName", employees);
        }

        public ActionResult EmployeesByCriteria(string nameCriteria, string State, string Departments)
        {
            IEnumerable<Employee> employees = null;
            IEnumerable<Employee> employees2 = null;
            IEnumerable<Employee> employees3 = null;
          
            employees3 = Employees.All.OrderBy(x => x.Last_Name);

            if ((State != null && State.Length > 0 && State != "0") && (Departments != null && Departments.Length > 0 && Departments != "0"))
            {
                employees2 = employees3.Where(employee => (employee.State.ToUpperInvariant().Equals(State.ToUpperInvariant())) && employee.Department.ToUpperInvariant().Contains(Departments.ToUpperInvariant())).OrderBy(x => x.Last_Name);
            }
            else if (State != null && State.Length > 0 && State != "0")
            {
                employees2 = employees3.Where(employee => employee.State.ToUpperInvariant().Equals(State.ToUpperInvariant())).OrderBy(x => x.Last_Name);
            }
            else if (Departments != null && Departments.Length > 0 && Departments != "0")
            {
                employees2 = employees3.Where(employee => employee.Department.ToUpperInvariant().Contains(Departments.ToUpperInvariant())).OrderBy(x => x.Last_Name);
            }
            else
            {
                employees2 = employees3;
            }

            if (nameCriteria != null && nameCriteria.Length > 0)
            {
                string name = nameCriteria.ToLowerInvariant();
                //if (double.TryParse(searchCriteria[0], out num))
                if (name.Contains(' '))
                {
                    string[] names = nameCriteria.Split(' ');
                    employees = employees2.Where(employee => (employee.First_Name.ToLower().StartsWith(names[0], true, CultureInfo.InvariantCulture) ||
                                employee.First_Name.ToLower().StartsWith(names[0], true, CultureInfo.InvariantCulture)) &&
                                employee.Last_Name.ToLower().StartsWith(names[1], true, CultureInfo.InvariantCulture)).OrderBy(x => x.Last_Name); ;

                    
                }
                else if (name.Length == 2)
                  
                    employees = employees2.Where(employee => employee.First_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                    employee.Last_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                    ((employee.First_Name.ToLower().StartsWith(name.Substring(0, 1), true, CultureInfo.InvariantCulture) ||
                    employee.First_Name.ToLower().StartsWith(name.Substring(0, 1), true, CultureInfo.InvariantCulture)) &&
                    employee.Last_Name.ToLower().StartsWith(name.Substring(1, 1), true, CultureInfo.InvariantCulture))).OrderBy(x => x.Last_Name);

                else if (name.Length == 3)
                   
                    employees = employees2.Where(employee => employee.First_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                                employee.Last_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                                ((employee.First_Name.ToLower().StartsWith(name.Substring(0, 1), true, CultureInfo.InvariantCulture) ||
                                employee.First_Name.ToLower().StartsWith(name.Substring(0, 1), true, CultureInfo.InvariantCulture)) &&
                                employee.Middle_Name.ToLower().StartsWith(name.Substring(1, 1), true, CultureInfo.InvariantCulture) &&
                                employee.Last_Name.ToLower().StartsWith(name.Substring(2, 1), true, CultureInfo.InvariantCulture))).OrderBy(x => x.Last_Name);


                else
                    employees = employees2.Where(employee => employee.First_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                                employee.First_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture) ||
                                employee.Last_Name.ToLower().StartsWith(name, true, CultureInfo.InvariantCulture)).OrderBy(x => x.Last_Name);
            }
            else
            {
                employees = employees2;
            }
            return PartialView("EmployeeSearchResultsDX", employees);
           
        }

        public ViewResult EmployeeById(string employee_id)
        {
            var employee = Employees.All.Single(x => x.Employee_Id == employee_id);
            return View(employee);
        }

        public ViewResult AllDepartments()
        {
            var allDepartments = Employees.All.Select(x => x.Department).Distinct().OrderBy(x => x);
            return View(allDepartments);
        }

       
        public ViewResult EmployeesByDepartment(string department)
        {
            var employees = Employees.All.Where(employee => employee.Department.ToUpperInvariant().Contains(department.ToUpperInvariant())).OrderBy(x => x.Last_Name);
            return View("AllEmployees", employees);
        }

        public ViewResult AllStates()
        {
            var allStates = Employees.All.Select(x => x.State).Distinct().OrderBy(x => x);
            return View(allStates);
        }

        public ViewResult EmployeesByState(string state)
        {
            var employees = Employees.All.Where(employee => employee.State.ToUpperInvariant().Equals(state.ToUpperInvariant())).OrderBy(x => x.Last_Name);
            return View("AllEmployees", employees);
        }

        public ViewResult AllCountries()
        {
            var allCountries = Employees.All.Select(x => x.Country).Distinct().OrderBy(x => x);
            return View(allCountries);
        }

        public ViewResult EmployeesByCountry(string country)
        {
            var employees = Employees.All.Where(employee => employee.Country.ToUpperInvariant().Equals(country.ToUpperInvariant())).OrderBy(x => x.Last_Name);
            return View("AllEmployees", employees);
        }

        //cascading dropdowns
        public ActionResult LocationPartial()
        {
            List<SelectListItem> States = new List<SelectListItem>();
            var allStates = Employees.All.Select(x => x.State).Distinct().OrderBy(x => x);
            foreach (var state in allStates)
            {
                States.Add(new SelectListItem { Text = state, Value = state });
            }
            ViewData["Locations"] = new SelectList(States, "Value", "Text");
            return PartialView();

        }

        public ActionResult DepartmentPartial(string id)
        {
            List<SelectListItem> returnList = new List<SelectListItem>();
            if (id != null && id.Length > 0 && id != "0")
            {
                var employees = Employees.All.Where(employee => employee.State.Equals(id));
                var DepartmentRes = employees.Select(x => x.Department).Distinct().OrderBy(x => x);
                foreach (var department in DepartmentRes)
                {
                    returnList.Add(new SelectListItem { Value = department, Text = department });
                }
            }
            else
            {
                var allDepartments = Employees.All.Select(x => x.Department).Distinct().OrderBy(x => x);
                foreach (var department in allDepartments)
                {
                    returnList.Add(new SelectListItem { Value = department, Text = department });
                }
            }

            ViewData["Departments"] = new SelectList(returnList, "Value", "Text");
            return PartialView();

        }

        public ViewResult SearchEmployees()
        {
            List<SelectListItem> Branches = new List<SelectListItem>();
            var allBranches = Employees.All.Select(x => x.State).Distinct().OrderBy(x => x);
            foreach (var branch in allBranches)
            {
                Branches.Add(new SelectListItem { Text = branch, Value = branch });
            }

            ViewData["Locations"] = new SelectList(Branches, "Value", "Text");

            List<SelectListItem> Departments = new List<SelectListItem>();
            var allDepartments = Employees.All.Select(x => x.Department).Distinct().OrderBy(x => x);
            foreach (var department in allDepartments)
            {
                Departments.Add(new SelectListItem { Text = department, Value = department });
            }
            ViewData["Departments"] = new SelectList(Departments, "Value", "Text");
            return View("SearchEmployees");
        }

        //public ActionResult SearchEmployees()
        //{
        //    List<SelectListItem> Branches = new List<SelectListItem>();
        //    var allBranches = Employees.All.Select(x => x.State).Distinct().OrderBy(x => x);
        //    foreach (var branch in allBranches)
        //    {
        //        Branches.Add(new SelectListItem { Text = branch, Value = branch });
        //    }
           
        //    ViewData["Locations"] = new SelectList(Branches, "Value", "Text");

        //    List<SelectListItem> Departments = new List<SelectListItem>();
        //    var allDepartments = Employees.All.Select(x => x.Department).Distinct().OrderBy(x => x);
        //    foreach (var department in allDepartments)
        //    {
        //        Departments.Add(new SelectListItem { Text = department, Value = department });
        //    }
        //    ViewData["Departments"] = new SelectList(Departments, "Value", "Text");
        //    return View();
        //}
        //public JsonResult DepartmentResList(string Id)
        //{
        //    var DepartmentRes = DepartmentList.GetDepartment(Id);
        //    return Json(new SelectList(DepartmentRes, "Value", "Text"), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult ExportTo(string OutputFormat)
        {
            var model = Session["TypedListModel"];

            switch (OutputFormat.ToUpper())
            {
                case "PDF":
                    return GridViewExtension.ExportToPdf(GridViewHelper.ExportGridViewSettings, model);
                case "XLSX":
                    return GridViewExtension.ExportToXlsx(GridViewHelper.ExportGridViewSettings, model);
                default:
                    return RedirectToAction("Index");
            }
        }


        public ActionResult GetImage(int id)
        {
            byte[] imageData = Employees.GetImage(id);
            return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
        }

        public ActionResult ExportToXLSX()
        {
            var model = Session["TypedListModel"];
            return GridViewExtension.ExportToXlsx(GridViewHelper.ExportGridViewSettings, model);
        }
        public ActionResult ExportToPDF()
        {
            var model = Session["TypedListModel"];
            return GridViewExtension.ExportToPdf(GridViewHelper.ExportGridViewSettings, model);
        }

        public static class GridViewHelper
        {
            private static GridViewSettings exportGridViewSettings;

            public static GridViewSettings ExportGridViewSettings
            {
                get
                {
                    if (exportGridViewSettings == null)
                        exportGridViewSettings = CreateExportGridViewSettings();
                    return exportGridViewSettings;
                }
            }

            private static GridViewSettings CreateExportGridViewSettings()
            {
                GridViewSettings settings = new GridViewSettings();

                settings.Name = "EmployeeGridView";
                settings.CallbackRouteValues = new { Controller = "Home", Action = "EmployeesByCriteria" };
                settings.SettingsPager.PageSize = 25;
                settings.Width = Unit.Percentage(80);
                settings.Height = Unit.Pixel(1000);
                settings.Columns.Add("Full_Name", "Name");
                settings.Columns.Add("Extension", "Ext");
                settings.Columns.Add("Phone_Number", "Phone");
                settings.Columns.Add("Branch_Display_Name", "Location");
                settings.Columns.Add("Department", "Department");
                settings.Columns.Add("Job_Title", "Job Title");
                settings.ClientVisible = true;
                settings.ClientSideEvents.BeginCallback = "OnBeginCallback";
                settings.SettingsLoadingPanel.Mode = GridViewLoadingPanelMode.Disabled;
                settings.SettingsExport.RenderBrick = (sender, e) =>
                {
                    if (e.RowType == GridViewRowType.Data && e.VisibleIndex % 2 == 0)
                        e.BrickStyle.BackColor = System.Drawing.Color.FromArgb(0xEE, 0xEE, 0xEE);
                };

                return settings;
            }
        }
    }
}