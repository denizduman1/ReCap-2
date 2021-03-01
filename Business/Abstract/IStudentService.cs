using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IDataResult<List<Student>> GetAll();
        IDataResult<Student> GetbyId(int id);
        IResult Add(Student student);
        IResult Update(Student student);
        IResult Delete(Student student);
    }
}
