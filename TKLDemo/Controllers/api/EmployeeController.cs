using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TKLDemo.BAL;
using TKLDemo.Models;

namespace TKLDemo.Controllers.api
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        [Route("GetAllEmployee")]
        [HttpGet]
        public IHttpActionResult GetAllEmployee()
        {
            var employee_BAL = new Employee_BAL();
            var _EmployeeDetails = new EmployeeDetails();
            _EmployeeDetails = employee_BAL.GetAllEmployeeData().Result;
            return Ok(_EmployeeDetails);
        }

        //[Route("GetAverageAge")]
        //[HttpGet]
        //public IHttpActionResult GetAverageAge()
        //{
        //    var _EmployeeDetails = new EmployeeDetails();
        //    var averageAge = employee_BAL.GetAverageAge();
        //    return Ok(averageAge);
        //}

        //[Route("GetAverageSalary")]
        //[HttpGet]
        //public IHttpActionResult GetAverageSalary()
        //{
        //    var _EmployeeDetails = new EmployeeDetails();
        //    var GetAverageSalary = employee_BAL.GetAverageSalary();
        //    return Ok(GetAverageSalary);
        //}

        //[Route("GetAverageAgeAboveBelow")]
        //[HttpGet]
        //public IHttpActionResult GetAverageAgeAboveBelow()
        //{
        //    var _EmployeeDetails = new EmployeeDetails();
        //    employee_BAL.GetAverageAgeAboveBelow();
        //    return Ok("");
        //}

        //[Route("GetAverageSalaryAboveBelow")]
        //[HttpGet]
        //public IHttpActionResult GetAverageSalaryAboveBelow()
        //{
        //    var _EmployeeDetails = new EmployeeDetails();
        //    employee_BAL.GetAverageSalaryAboveBelow();
        //    return Ok("");
        //}
    }
}
