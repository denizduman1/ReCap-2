using Core.Entites;
using System;

namespace Entities.Concrete
{
    public class Process : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
