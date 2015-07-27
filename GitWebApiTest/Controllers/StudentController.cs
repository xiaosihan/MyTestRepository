using StudentsScoreManagement.BLL;
using StudentsScoreManagement.Models;
using System;
using System.Web.Http;

namespace GitTest.Controllers
{
    public class StudentController : ApiController
    {
        private readonly StudentManager thisManager = new StudentManager();

        public IHttpActionResult Post(Test_Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    int id = thisManager.AddStudent(student);
                    if (id != -1)
                    {
                        return Ok<int>(id);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
