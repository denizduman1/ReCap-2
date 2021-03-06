using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        IBookImageDal _bookImageDal;

        public BookImageManager(IBookImageDal bookImageDal)
        {
            _bookImageDal = bookImageDal;
        }

        [ValidationAspect(typeof(BookImageValidator))]
        public IResult Add(BookImage bookImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckImageLimitExceeded(bookImage.BookId));
            if (result != null)
            {
                return result;
            }
            bookImage.ImagePath = FileHelper.Add(file);
            bookImage.Date = DateTime.Now;
            _bookImageDal.Add(bookImage);
            return new SuccessResult();
        }

        public IResult Delete(BookImage bookImage)
        {
           var result = FileHelper.Delete(bookImage.ImagePath);
            if (result.Success)
            {
                _bookImageDal.Delete(bookImage);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<BookImage>> GetAll()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll());
        }

        public IDataResult<BookImage> GetById(int id)
        {
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(b => b.Id == id));
        }

        public IDataResult<List<BookImage>> GetImagesByBookId(int bookId)
        {
            var result = BusinessRules.Run(CheckIfBookImageNull(bookId));
            if (result != null)
            {
                return new ErrorDataResult<List<BookImage>>(result.Message);
            }
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll(b => b.BookId == bookId));
        }

        public IResult Update(BookImage bookImage, IFormFile file)
        {
            bookImage.ImagePath = FileHelper.Update(_bookImageDal.Get(b=>b.Id==bookImage.Id).ImagePath,file);
            bookImage.Date = DateTime.Now;
            _bookImageDal.Update(bookImage);
            return new SuccessResult();
        }
        private IResult CheckImageLimitExceeded(int bookId)
        {
            var result = _bookImageDal.GetAll(b => b.BookId == bookId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.BookImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private IDataResult<List<BookImage>> CheckIfBookImageNull(int bookId)
        {
            try
            {
                string path = @"\wwwroot\uploads\library_logo.jpg";
                var result = _bookImageDal.GetAll(b => b.BookId == bookId).Any();
                if (!result)
                {
                    List<BookImage> bookimage = new List<BookImage>();
                    bookimage.Add(new BookImage { BookId = bookId, ImagePath = path, Date = DateTime.Now });
                    _bookImageDal.Add(bookimage[0]);
                    return new SuccessDataResult<List<BookImage>>(bookimage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<BookImage>>(exception.Message);
            }
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll(p => p.BookId == bookId).ToList());
        }
    }
}
