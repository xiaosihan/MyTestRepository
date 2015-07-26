using StudentsScoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsScoreManagement.DAL
{
    public class StudentDao : BaseDao<Test_Student>
    {
        public StudentDao(TestEntities testEntities) :
            base(testEntities)
        {
        }

    }
}
