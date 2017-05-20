using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Management.Entity;

namespace Management.Dao
{
    /// <summary>
    /// 公共字典表
    /// </summary>
    public class PublicDictionaryDao
    {
        /// <summary>
        /// 添加公共字典表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(PublicDictionary entity)
        {
            using (ManagementDBContext db = new ManagementDBContext())
            {
                db.PublicDictionarys.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 更新公共字典表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Modify(PublicDictionary entity)
        {
            using (ManagementDBContext db = new ManagementDBContext())
            {
                db.Entry<PublicDictionary>(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 根据ID删除公共字典表数据
        /// </summary>
        /// <returns></returns>
        public bool Remove(int pId)
        {
            PublicDictionary entity = new PublicDictionary() { PID = pId };
            using (ManagementDBContext db = new ManagementDBContext())
            {
                db.Entry<PublicDictionary>(entity).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 查询所有公共字典表数据
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <param name="groupName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<PublicDictionary> GetAllPublicDictionary(int pageNumber, int pagesize, out int total, string groupName, string pubvalue)
        {
            using (ManagementDBContext db = new ManagementDBContext())
            {
                var result = from rs in db.PublicDictionarys select rs;
                if (!String.IsNullOrEmpty(groupName))
                    result = result.Where(t => t.PubGroupName.Contains(groupName));
                if (!String.IsNullOrEmpty(pubvalue))
                    result = result.Where(t => t.PubValue.Contains(pubvalue));
                total = result.Count();
                return result.OrderBy(t => t.PubGroupName).OrderBy(t => t.Sort).Skip((pageNumber - 1) * pagesize).Take(pagesize).ToList<PublicDictionary>();
            }
        }

        /// <summary>
        /// 根据分组名获取数据
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public IEnumerable<PublicDictionary> GetPublicDictionaryDataByGroupName(string groupName)
        {
            using (ManagementDBContext db = new ManagementDBContext())
            {
                return db.PublicDictionarys.Where(t => t.PubGroupName == groupName);
            }
        }

    }
}
