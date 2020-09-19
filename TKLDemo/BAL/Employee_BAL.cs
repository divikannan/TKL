using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TKLDemo.Models;

namespace TKLDemo.BAL
{
    public class Employee_BAL
    {
        string URL = ConfigurationManager.AppSettings["GetAllEmployeeData"];
        public async Task<EmployeeDetails> GetAllEmployeeData()
        {
            var _EmployeeDetails = new EmployeeDetails();
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, URL);
                        httpResponse = client.SendAsync(request).Result;

                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var tt = httpResponse.Content.ReadAsStringAsync().Result;
                            _EmployeeDetails = JsonConvert.DeserializeObject<EmployeeDetails>(tt);

                            if (_EmployeeDetails != null)
                            {
                                //Calculate Average age and salary
                                _EmployeeDetails.AverageAge = _EmployeeDetails.data.Average(x => x.employee_age);
                                var AverageSalary = _EmployeeDetails.data.Average(x => x.employee_salary);
                                _EmployeeDetails.AverageSalary = Math.Round(AverageSalary, 2);
                                //Below and Average Age
                                _EmployeeDetails.BelowAverageAgeEmployees = _EmployeeDetails.data.Where(x => x.employee_age < _EmployeeDetails.AverageAge).ToList();
                                _EmployeeDetails.AboveAverageAgeEmployees = _EmployeeDetails.data.Where(x => x.employee_age > _EmployeeDetails.AverageAge).ToList();
                                //Below and Average Salary
                                _EmployeeDetails.BelowAverageSalaryEmployees = _EmployeeDetails.data.Where(x => x.employee_salary < _EmployeeDetails.AverageSalary).ToList();
                                _EmployeeDetails.AboveAverageSalaryEmployees = _EmployeeDetails.data.Where(x => x.employee_salary > _EmployeeDetails.AverageSalary).ToList();
                            }


                        }
                        return _EmployeeDetails;
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        //public void GetEmployeeData()
        //{
        //    _EmployeeDetails = GetAllEmployeeData().Result;
        //    EmployeeData _EmployeeData = new EmployeeData();
        //    if (_EmployeeDetails != null)
        //    {
        //        _EmployeeData.AverageAge = _EmployeeDetails.data.Average(x => x.employee_age);
        //        _EmployeeData.AverageSalary = _EmployeeDetails.data.Average(x => x.employee_salary);

        //        _EmployeeData.BelowAverageAgeEmployees = _EmployeeDetails.data.Where(x => x.employee_age < _EmployeeData.AverageAge).ToList();
        //        _EmployeeData.AboveAverageAgeEmployees = _EmployeeDetails.data.Where(x => x.employee_age > _EmployeeData.AverageAge).ToList();

        //        _EmployeeData.BelowAverageSalaryEmployees = _EmployeeDetails.data.Where(x => x.employee_salary < _EmployeeData.AverageSalary).ToList();
        //        _EmployeeData.AboveAverageSalaryEmployees = _EmployeeDetails.data.Where(x => x.employee_salary > _EmployeeData.AverageSalary).ToList();
        //    }
        //    else
        //    {

        //    }
        //}

    }
}