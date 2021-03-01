using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProcessManager : IProcessService
    {
        IProcessDal _processDal;

        public ProcessManager(IProcessDal processDal)
        {
            _processDal = processDal;
        }

        [ValidationAspect(typeof(ProcessValidator))]
        public IResult Add(Process process)
        {
            var result = _processDal.GetAll(p => p.BookId == process.BookId && p.DeliveryDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            _processDal.Add(process);
            return new SuccessResult(Messages.ProccessAdded);
        }

        public IResult Delete(Process process)
        {
            _processDal.Delete(process);
            return new SuccessResult();
        }

        public IDataResult<List<Process>> GetAll()
        {
            return new SuccessDataResult<List<Process>>(_processDal.GetAll());
        }

        public IDataResult<Process> GetById(int id)
        {
            return new SuccessDataResult<Process>(_processDal.Get(p => p.Id == id));
        }

        public IDataResult<List<ProcessDetailDto>> GetProcessDetails()
        {
            return new SuccessDataResult<List<ProcessDetailDto>>(_processDal.GetProcessDetails());
        }

        public IResult Update(Process process)
        {
            _processDal.Update(process);
            return new SuccessResult();
        }
    }
}
