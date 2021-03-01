using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITypeService
    {
        IDataResult<List<Type>> GetAll();
        IDataResult<Type> GetbyId(int id);
        IResult Add(Type type);
        IResult Update(Type type);
        IResult Delete(Type type);
    }
}
