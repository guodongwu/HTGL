using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Management.Dao;
using Management.Entity;
using Management.ViewModel;

namespace Management.BLL
{
    public class PublicDictionaryService
    {
        PublicDictionaryDao dao;
        public PublicDictionaryService()
        {
            dao = new PublicDictionaryDao();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(PublicDictionary entity)
        {
            return dao.Insert(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(PublicDictionary entity)
        {
            return dao.Modify(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public bool Delete(int pId)
        {
            return dao.Remove(pId);
        }

        /// <summary>
        /// 获取所有公共字典表数据
        /// </summary>
        /// <param name="request">前端请求</param>
        /// <param name="groupName">分组名</param>
        /// <param name="pubvalue">分组值</param>
        /// <returns></returns>
        public UIGrid GetAllPublicDictionary(UIGridRequest request, string groupName, string pubvalue)
        {
            int count = 0;
            if (request.PageNumber <= 0) request.PageNumber = 1;
            var data = dao.GetAllPublicDictionary(request.PageNumber, request.PageSize, out count, groupName, pubvalue);
            return new UIGrid() { Rows = data, Total = count };
        }

        /// <summary>
        /// 根据分组名获取数据
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public IEnumerable<PublicDictionary> GetPublicDictionaryDataByGroupName(string groupName)
        {
            return dao.GetPublicDictionaryDataByGroupName(groupName ?? "");
        }
    }
}
