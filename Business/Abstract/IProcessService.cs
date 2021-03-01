using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProcessService
    {
        IDataResult<List<Process>> GetAll();
        IDataResult<Process> GetById(int id);
        IDataResult<List<ProcessDetailDto>> GetProcessDetails();
        IResult Add(Process process);
        IResult Update(Process process);
        IResult Delete(Process process);
    }
}
