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
    public class EfProcessDal : EfEntityRepositoryBase<Process, LibraryContext>, IProcessDal
    {
        public List<ProcessDetailDto> GetProcessDetails(Expression<Func<Process, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from p in filter == null ? context.Processes : context.Processes.Where(filter)
                             join std in context.Students
                             on p.StudentId equals std.Id
                             join b in context.Books
                             on p.BookId equals b.Id
                             join a in context.Authors
                             on b.AuthorId equals a.Id
                             select new ProcessDetailDto
                             {
                                 Id = p.Id,
                                 AuthorFirstName = a.FirstName,
                                 AuthorLastName = a.LastName,
                                 BookName = b.Name,
                                 BorrowDate = p.BorrowDate,
                                 DeliveryDate = (DateTime)p.DeliveryDate,
                                 StudentFirstName = std.FirstName,
                                 StudentLastName = std.LastName
                             };
                return result.ToList();
            }
        }
    }
}
