using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetails(Expression<Func<Book, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from b in filter == null ? context.Books : context.Books.Where(filter)
                             join a in context.Authors
                             on b.AuthorId equals a.Id
                             join t in context.Types
                             on b.TypeId equals t.Id
                             select new BookDetailDto
                             {
                                 Id = b.Id,
                                 AuthorFirstName = a.FirstName,
                                 AuthorLastName = a.LastName,
                                 BookName = b.Name,
                                 PageCount = b.PageCount,
                                 TypeName = t.Name
                             };
                return result.ToList();
            }
        }
    }
}
