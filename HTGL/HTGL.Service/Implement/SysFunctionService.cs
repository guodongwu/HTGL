using System;
using System.Collections.Generic;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Data.Repositories;
using HTGL.Model;
using HTGL.Repository.EF;
using HTGL.Service.Interface;

namespace HTGL.Service.Implement
{
    public class SysFunctionService : BaseService, ISysFunctionService
    {

        private readonly ISysFunctionRepository _sysFunctionRepository;
        private readonly ISysMenuRepository _sysMenuRepository;
        private readonly ISysMenuFunctionRepository _sysMenuFunctionRepository;
        public SysFunctionService(ISysFunctionRepository sysFunctionRepository, ISysMenuRepository sysMenuRepository, ISysMenuFunctionRepository sysMenuFunctionRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysFunctionRepository = sysFunctionRepository;
            _sysMenuRepository = sysMenuRepository;
            _sysMenuFunctionRepository = sysMenuFunctionRepository;
        }

        public IQueryable<SysFunction> SysFunctions
        {
            get
            {
                return _sysFunctionRepository.Entities;
            }
        }
        public OperationResult Add(SysFunction sysFunction)
        {
            int result = _sysFunctionRepository.Insert(sysFunction);
            return new OperationResult(result > 0 ? OperationResultType.Success : OperationResultType.Error,"",sysFunction.FunctionId);
        }

        public OperationResult Remove(SysFunction sysFunction)
        {
            throw new NotImplementedException();
        }

        public OperationResult Save(SysFunction sysFunction)
        {
            throw new NotImplementedException();
        }

        public SysFunction FindBy(Func<SysFunction, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysFunction> FindAll()
        {
            return SysFunctions.ToList();
        }

        public List<SysFunction> FindAll(Func<SysFunction, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysFunction> FindAll<Tkey>(Func<SysFunction, bool> @where, Func<SysFunction, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            throw new NotImplementedException();
        }

        public List<SysFunction> GetButtons(string menuNo)
        {

            var menus = _sysMenuRepository.Entities.FirstOrDefault(p => p.MenuController == menuNo);
            var menus_funs = _sysMenuFunctionRepository.Entities.Where(p => p.MenuId == menus.MenuId).Select(p => p.FunctionId).ToArray();
            var functions = FindAll().Where(p => menus_funs.Contains(p.FunctionId) && p.IsButton && p.IsVisible).Distinct().ToList();

            return functions;
        }
    }
}