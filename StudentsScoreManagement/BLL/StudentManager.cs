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
        private readonly TestEntities testEntities;
        private readonly StudentDao thisDao;

        public StudentManager()
        {
            testEntities = new TestEntities();
            thisDao = new StudentDao(testEntities);
        }

        public void AddStudent(Test_Student entity)
        {
            using (testEntities)
            {
                try
                {
                    if (thisDao.FindAll().Where(s => s.StudentNum == entity.StudentNum).FirstOrDefault() != null)
                    {
                        throw new Exception("学号重复！");
                    }
                    thisDao.Create(entity);
                    entity.StudentNum = (int.Parse(entity.StudentNum) + 1).ToString();
                    thisDao.Update(entity, entity.Id);
                    thisDao.Save();
                }
                catch (Exception ex)
                {
                    throw new Exception("操作失败，原因:" + ex.Message);
                }
            }
        }
    }
}
