using StudentsScoreManagement.Common;
using StudentsScoreManagement.Models;
using System.Data.Entity;

namespace StudentsScoreManagement.DAL
{
    public class BaseDao<T> where T : class
    {
        #region
        protected TestEntities testEntities;
        protected DbSet<T> dbSet;

        public BaseDao(TestEntities testEntities)
        {
            this.dbSet = testEntities.Set<T>();
            this.testEntities = testEntities;
        }

        #endregion

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Create(T entity)
        {
            var obj = this.dbSet.Add(entity);
            this.testEntities.SaveChanges();
            return obj;

        }

        public T Update(T entity, object id)
        {
            var originalEntity = Find(id);
            Helper.CopyObjectValue(entity, originalEntity);
            return entity;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public DbSet<T> FindAll()
        {
            return this.dbSet;
        }

        /// <summary>
        /// 查询单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find(object id)
        {
            return this.dbSet.Find(id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Delete(T entity)
        {
            return this.dbSet.Remove(entity);
        }

        /// <summary>
        /// 提交变更
        /// </summary>
        public void Save()
        {
            this.testEntities.SaveChanges();
        }
    }
}
