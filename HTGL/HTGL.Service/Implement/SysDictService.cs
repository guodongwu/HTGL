using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTGL.Repository.EF;
using HTGL.Data.Repositories;
using HTGL.Component.Tools;
using HTGL.Service.Interface;

namespace HTGL.Service.Implement
{
    public class SysDictService : BaseService, ISysDictService
    {

        private readonly ISysDictRepository _sysDictRepository;
        public SysDictService(ISysDictRepository sysDictRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _sysDictRepository = sysDictRepository;
        }

        public IQueryable<SysDict> SysDicts
        {
            get
            {
                return _sysDictRepository.Entities;
            }
        }

        public OperationResult Add(SysDict sysDict)
        {
            try
            {
                var entity = SysDicts.FirstOrDefault(c => c.DictName == sysDict.DictName.Trim() && c.DictType==sysDict.DictType);
                if (entity != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的模块，请修改后重新提交！");
                }
                entity = new SysDict
                {
                    DictName = sysDict.DictName.Trim(),
                    AddTime = DateTime.Now,
                    //UpdateDate = DateTime.Now
                };
                _sysDictRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch(Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public List<SysDict> FindAll()
        {
            return SysDicts.ToList();
        }

        public List<SysDict> FindAll(Func<SysDict, bool> where)
        {
            return SysDicts.Where(where).ToList();
        }

        public List<SysDict> FindAll<Tkey>(Func<SysDict, bool> where, Func<SysDict, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            total = SysDicts.Where(where).Count();
            return SysDicts.Where(where).OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public SysDict FindBy(Func<SysDict, bool> where)
        {
            return SysDicts.FirstOrDefault(where);
        }

        public OperationResult Remove(SysDict sysDict)
        {
            try
            {
                _sysDictRepository.Delete(sysDict);
                return new OperationResult(OperationResultType.Success, "删除数据成功！");
            }
            catch (Exception ex)
            {
                
                return new OperationResult(OperationResultType.Error, "删除数据失败！");
            }
        }

        public OperationResult Save(SysDict sysDict)
        {
            try
            {
                _sysDictRepository.Update(sysDict);
                return new OperationResult(OperationResultType.Success, "修改数据成功！");
            }
            catch (Exception)
            {
                
                 return new OperationResult(OperationResultType.Error, "修改数据失败！");
            }
        }
    }
}
