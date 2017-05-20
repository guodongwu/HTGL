using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HTGL.Service.Interface
{
    public interface ISysDepartmentService : IDependency
    {

        IQueryable<SysDepartment> SysDepartments { get; }


        OperationResult Add(SysDepartment sysDepartment);
        OperationResult Remove(SysDepartment sysDepartment);
        OperationResult Save(SysDepartment sysDepartment);

        SysDepartment FindBy(Func<SysDepartment, bool> where);

        List<SysDepartment> FindAll();
        List<SysDepartment> FindAll(Func<SysDepartment, bool> where);

        List<SysDepartment> FindAll<Tkey>(Func<SysDepartment, bool> where, Func<SysDepartment, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

        string GetDepartmentGridTree();
    }
}

