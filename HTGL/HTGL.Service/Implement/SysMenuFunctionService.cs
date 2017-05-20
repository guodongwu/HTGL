using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Data.Repositories;
using HTGL.Model;
using HTGL.Repository.EF;
using HTGL.Service.Interface;

namespace HTGL.Service.Implement
{
    public class SysMenuFunctionService : BaseService, ISysMenuFunctionService
    {
        private readonly ISysMenuFunctionRepository _sysMenuFunctionRepository;
        public SysMenuFunctionService(ISysMenuFunctionRepository sysMenuFunctionRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysMenuFunctionRepository = sysMenuFunctionRepository;
        }

        public IQueryable<SysMenuFunction> SysMenuFunctions
        {
            get { return _sysMenuFunctionRepository.Entities; }
        }
        public OperationResult Add(SysMenuFunction sysMenuFunction)
        {
            var result = _sysMenuFunctionRepository.Insert(sysMenuFunction);
            return new OperationResult(result > 0 ? OperationResultType.Success : OperationResultType.Error, "",
                sysMenuFunction.MFId);
        }

        public OperationResult Remove(SysMenuFunction sysMenuFunction)
        {
            throw new NotImplementedException();
        }

        public OperationResult Save(SysMenuFunction sysMenuFunction)
        {
            int r = _sysMenuFunctionRepository.Update(sysMenuFunction);
            return new OperationResult(r > 0 ? OperationResultType.Success : OperationResultType.Error);
        }

        public SysMenuFunction FindBy(Func<SysMenuFunction, bool> @where)
        {
            return SysMenuFunctions.FirstOrDefault(where);
        }

        public List<SysMenuFunction> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<SysMenuFunction> FindAll(Func<SysMenuFunction, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysMenuFunction> FindAll<Tkey>(Func<SysMenuFunction, bool> @where, Func<SysMenuFunction, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            throw new NotImplementedException();
        }

        public UIGrid GetMenuButtons(UIGridRequest request, string MenuController)
        {
            int count = 0;
            var sysmfs = SysMenuFunctions.Where(
                  p =>
                      p.SysMenu.MenuController == MenuController &&
                      p.SysFunction.ControllerName == MenuController).Distinct().ToList();
            count = sysmfs.Count();
            int pageNumber = request.PageNumber;
            int pageSize = request.PageSize;
            sysmfs = sysmfs.OrderBy(t => t.MenuId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList<SysMenuFunction>();
            List<SysMenuFunctionVM> mfList = new List<SysMenuFunctionVM>();
            foreach (var item in sysmfs)
            {
                SysMenuFunctionVM smfvm = new SysMenuFunctionVM
                {
                    MFId = item.MFId,
                    IsVisible = item.IsVisible,
                    MenuId = item.MenuId,
                    FunctionId = item.FunctionId,
                    FunctionName = item.SysFunction.Name,
                    ControllerName = item.SysFunction.ControllerName,
                    MenuName = item.SysMenu.Name,
                    ActionName = item.SysFunction.ActionName,
                    FunctionIcon = item.SysFunction.Icon
                };
                mfList.Add(smfvm);

            }
            return new UIGrid()
            {
                Rows = mfList,
                Total = count
            };

        }
    }
}