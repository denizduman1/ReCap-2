using Core.Entites;

namespace Entities.Concrete
{
    public class Type : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
