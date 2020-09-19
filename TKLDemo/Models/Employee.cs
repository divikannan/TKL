using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TKLDemo.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }

    public class EmployeeDetails
    {
        public string status { get; set; }
        public List<Employee> data { get; set; }
        public string message { get; set; }
        public double AverageAge { get; set; }
        public double AverageSalary { get; set; }
        public List<Employee> BelowAverageAgeEmployees { get; set; }
        public List<Employee> AboveAverageAgeEmployees { get; set; }
        public List<Employee> BelowAverageSalaryEmployees { get; set; }
        public List<Employee> AboveAverageSalaryEmployees { get; set; }
    }

    //public class EmployeeData
    //{
    //    public double AverageAge { get; set; }
    //    public double AverageSalary { get; set; }
    //    public List<Employee> BelowAverageAgeEmployees { get; set; }
    //    public List<Employee> AboveAverageAgeEmployees { get; set; }
    //    public List<Employee> BelowAverageSalaryEmployees { get; set; }
    //    public List<Employee> AboveAverageSalaryEmployees { get; set; }
    //}
    


}