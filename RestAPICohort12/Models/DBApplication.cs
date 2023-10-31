using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RestAPICohort12.Models
{
    public class DBApplication
    {
        public Response GetAllStudents(SqlConnection con)
        {
            // Step 1: Create instance of the Response class
            Response response = new Response();

            // Step 2: Create the query
            string Query = "Select * from student";

            // Step 3: Need data adapter to read the data from database and a table structure to add it into the table.
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Step 4: Initialize the list of students variable
            List<Student> listOfStudents = new List<Student>();

            // Step 5: Verify the database query retrived in DT
            if(dt.Rows.Count > 0) // If rows is more then zero              
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Student student = new Student(); // To capture each entry in the table

                    student.std_Id = (int) dt.Rows[i]["std_id"];
                    student.std_name = (string) dt.Rows[i]["std_name"];
                    student.std_email = (string )dt.Rows[i]["std_email"];
                    student.std_reg_year = (int)dt.Rows[i]["std_reg_year"];

                    listOfStudents.Add(student);
                }
            }

            // Step 6: verify the lsit of the students and configure response
            if (listOfStudents.Count > 0)
            {
                response.status_code = 200;
                response.status_message = "Succesful";
                response.students = listOfStudents;
                response.student = null;
            }
            else
            {
                response.status_code = 100;
                response.status_message = "The query is not succesful.. check it";
                response.students = null;
                response.student = null;
            }
            return response;
        }


    }
}
