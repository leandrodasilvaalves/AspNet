using System.Collections.Generic;

namespace Model
{
    public interface IMongoDal<T> where T : EntityBase
    {
        void InsertData(string collectionName, ICollection<T> collectionData);

        void UpdateOne(string collectionName, T document);

        void UpdateOne(string collectionName, Dictionary<string, object> dictionary, string id);        

        ICollection<T> ListData(string collectionName);

        void ClearDataBase(string collectionName);
    }
}
