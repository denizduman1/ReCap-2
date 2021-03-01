using Core.Entites;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
    }
}
