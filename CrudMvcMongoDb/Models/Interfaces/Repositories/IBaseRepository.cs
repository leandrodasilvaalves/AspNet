using System.Collections.Generic;
using MongoDB.Driver;

namespace CrudMvcMongoDb.Models.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        DataDomain GetDataDomain() ;

        void InsertDataDomain(DataDomain dataDomain);

        void UpdateDataDomain(DataDomain dataDomain);

    }
}