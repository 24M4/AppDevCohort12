using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using RestAPICohort12.Models;
using System.Data.SqlClient;

namespace RestAPICohort12.Controllers
{
    // Need to providde the controller information / rest API information to view the base information properly

    [Route("[controller]")]
    [ApiController] // The definition of the class we are going to provide here 
    public class StudentController : ControllerBase
    {
        // We are goign to use hte base controller only to structure the contents, View will be handled by wpf or web browser

        // Step 1: create a connection state receiver
        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
            // Step 2: Create the API for controller, which is going to act as rest API

            // Step 2.1: Create GetAllStudents API
            [HttpGet] // Generate get request
            [Route("GetAllStudents")] 

            public Response GetAllStudents()
            {
             // Step 1: Create instance of the Response Class
                Response response = new Response();

            // Step 2: We need the database connection to be provided over here
             SqlConnection con = new SqlConnection(_configuration.GetConnectionString("studentConnection"));

            // Step 3: Generate the Query and Execute
            // We want to have a seperate database class which we are goign to create under Models folder
            DBApplication dba = new DBApplication();
            response = dba.GetAllStudents(con);


             // Step 4: Return the Response
             return response;

            }

        }
    }

