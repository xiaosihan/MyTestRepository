using StudentsScoreManagement.DAL;
using StudentsScoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsScoreManagement.BLL
{
    public class StudentManager
    {
        private readonly StudentRepository thisDao;

        public StudentManager()
        {
            TestEntities testEntities = new TestEntities();
            thisDao = new StudentRepository(testEntities);
        }

        public int AddStudent(Test_Student entity)
        {
            try
            {
                if (thisDao.FindAll().Where(s => s.StudentNum == entity.StudentNum).FirstOrDefault() != null)
                {
                    throw new Exception("学号重复！");
                }
                var entityWithPK = thisDao.Create(entity);
                if (entityWithPK != null)
                    return entity.Id;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                throw new Exception("操作失败，原因:" + ex.Message);
            }
        }
    }
}
