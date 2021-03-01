using Core.Entites;
using System;

namespace Entities.Concrete
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Department { get; set; }
    }
}
