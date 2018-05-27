namespace CrudMvcMongoDb.Models
{
    public class Product : MongoDBModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public  override string CollectionName => "Product";
    }
}