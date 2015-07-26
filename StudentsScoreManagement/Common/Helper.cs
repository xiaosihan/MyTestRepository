using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsScoreManagement.Common
{
    public class Helper
    {
        public static void CopyObjectValue(object fromObj, object toObj)
        {
            Type type;
            var type1 = type = fromObj.GetType();
            var type2 = toObj.GetType();
            if (type1 != type2)
            {
                new Exception("被赋值对象与原对象类型不一致");
            }
            try
            {
                foreach (var property in type.GetProperties())
                {
                    property.SetValue(toObj, property.GetValue(fromObj));
                }
            }
            catch
            {
                new Exception("原对象向被赋值对象赋值时出现错误");
            }
        }
    }
}
