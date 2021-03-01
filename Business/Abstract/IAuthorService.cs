using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetAll();
        IDataResult<Author> GetById(int id);
        IResult Add(Author author);
        IResult Delete(Author author);
        IResult Update(Author author);
    }
}
