using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IProcessDal : IEntityRepository<Process>
    {
        List<ProcessDetailDto> GetProcessDetails(Expression<Func<Process, bool>> filter = null);
    }
}
