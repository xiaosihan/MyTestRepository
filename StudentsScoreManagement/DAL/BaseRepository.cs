using StudentsScoreManagement.Common;
using StudentsScoreManagement.Models;
using System.Data.Entity;

namespace StudentsScoreManagement.DAL
{
    public class BaseRepository<T> where T : class
    {
        #region
        protected TestEntities testEntities;
        protected DbSet<T> dbSet;

        public BaseRepository(TestEntities testEntities)
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
            return Save() > 0 ? obj : null;
        }

        public bool Update(T entity, object id)
        {
            this.dbSet.Attach(entity);
            this.testEntities.Entry(entity).State = EntityState.Modified;
            return Save() > 0;
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
        public bool Delete(T entity)
        {
            var obj = this.dbSet.Remove(entity);
            return Save() > 0;
        }

        /// <summary>
        /// 提交变更
        /// </summary>
        public int Save()
        {
           return this.testEntities.SaveChanges();
        }
    }
}
