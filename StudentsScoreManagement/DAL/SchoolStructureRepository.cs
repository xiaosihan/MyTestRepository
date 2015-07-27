using StudentsScoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsScoreManagement.DAL
{
    public class SchoolStructureRepository : BaseRepository<Test_SchoolStructure>
    {
        private readonly TestEntities entities;

        public SchoolStructureRepository(TestEntities testEntities) :
            base(testEntities)
        {
            this.entities = testEntities;
        }

    }
}
