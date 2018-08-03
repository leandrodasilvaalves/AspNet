using Model.Entities;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Model.Interfaces
{
    public interface IMongoDal<T> where T : EntityBase
    {
        void InsertData(string collectionName, ICollection<T> collectionData);

        void UpdateOne(string collectionName, T document);

        void UpdateOne(string collectionName, Dictionary<string, object> dictionary, string id);

        ICollection<T> ListData(string collectionName, Expression<Func<T, object>> order, TypeOrder typeOrder = TypeOrder.Ascending);

        ICollection<T> ListData(string collectionName, Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, TypeOrder typeOrder = TypeOrder.Ascending);

        void ClearDataBase(string collectionName);
    }
}
