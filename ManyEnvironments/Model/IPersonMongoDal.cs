using System.Collections.Generic;

namespace Model
{
    public interface IPersonMongoDal : IMongoDal<Person>
    {
        void UpdateMany(ICollection<Person> objetos);
    }
}
