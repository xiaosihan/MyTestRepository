using GitTest.Models;
using StudentsScoreManagement.BLL;
using StudentsScoreManagement.Models;
using System;
using System.Web.Http;

namespace GitTest.Controllers
{
    public class StudentController : ApiController
    {
        private readonly StudentManager thisManager = new StudentManager();

        public Result PostCreate(Test_Student student)
        {
            Result result = new Result();
            try
            {
                thisManager.AddStudent(student);
                result.ReturnCode = 200;
            }
            catch(Exception ex)
            {
                result.ReturnCode = 500;
                result.ReturnMessage = ex.Message;
            }
            return result;
        }
    }
}
