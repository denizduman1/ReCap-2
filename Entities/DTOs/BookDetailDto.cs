using Core.Entites;

namespace Entities.DTOs
{
    public class BookDetailDto : IDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string TypeName { get; set; }
        public int PageCount { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
