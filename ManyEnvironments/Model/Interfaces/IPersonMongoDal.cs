using Model.Entities;
using System.Collections.Generic;

namespace Model.Interfaces
{
    public interface IPersonMongoDal : IMongoDal<Person>
    {
        void UpdateMany(ICollection<Person> objetos);
    }
}
