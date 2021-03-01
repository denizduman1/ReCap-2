using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<Book> GetById(int id);
        IDataResult<List<BookDetailDto>> GetBookDetails();
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
    }
}
