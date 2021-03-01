using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TypeManager : ITypeService
    {
        ITypeDal _typeDal;

        public TypeManager(ITypeDal typeDal)
        {
            _typeDal = typeDal;
        }

        [ValidationAspect(typeof(TypeValidator))]
        public IResult Add(Type type)
        {
            _typeDal.Add(type);
            return new SuccessResult(Messages.TypeAdded);
        }

        public IResult Delete(Type type)
        {
            _typeDal.Delete(type);
            return new SuccessResult();
        }

        public IDataResult<List<Type>> GetAll()
        {
            return new SuccessDataResult<List<Type>>(_typeDal.GetAll());
        }

        public IDataResult<Type> GetbyId(int id)
        {
            return new SuccessDataResult<Type>(_typeDal.Get(t => t.Id == id));
        }

        public IResult Update(Type type)
        {
            _typeDal.Update(type);
            return new SuccessResult();
        }
    }
}
