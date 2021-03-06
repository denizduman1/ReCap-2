using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookImageService
    {
        IDataResult<List<BookImage>> GetAll();
        IDataResult<BookImage> GetById(int id);
        IDataResult<List<BookImage>> GetImagesByBookId(int bookId);
        IResult Add(BookImage bookImage, IFormFile file);
        IResult Delete(BookImage bookImage);
        IResult Update(BookImage bookImage, IFormFile file);
    }
}
