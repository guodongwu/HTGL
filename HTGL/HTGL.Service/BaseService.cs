using HTGL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTGL.Service
{
    public abstract class BaseService
    {
        protected IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}