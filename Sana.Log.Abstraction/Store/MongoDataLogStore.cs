using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Sana.Log.Abstraction.Model;

namespace Sana.Log.Abstraction.Store
{
    public class MongoDataLogStore : ILogDataStore
    {
        private readonly IConfiguration _configuration;

        public MongoDataLogStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task StoreError(SanaErrorLogModel logObject)
        {
            var documentName = _configuration["LogDataStore:ErrorCollectionName"];
            return SaveAsync(documentName, logObject);
        }

        public Task StoreInformation(SanaInformationLogModel logObject)
        {
            var documentName = _configuration["LogDataStore:InformationCollectionName"];
            return SaveAsync(documentName, logObject);
        }

        private Task SaveAsync(string documentName, object logObject)
        {

            var cnnString = $"{_configuration["LogDataStore:CnnString"]}";
            var logDb = $"{_configuration["LogDataStore:DatabaseName"]}";


            var dbClient = new MongoClient(cnnString);
            IMongoDatabase db = dbClient.GetDatabase(logDb);
            var logTable = db.GetCollection<BsonDocument>(documentName);

            //TODO Performance issue convert to make this manually
            var LogObject = JsonSerializer.Serialize(logObject);
            BsonDocument document = BsonDocument.Parse(LogObject);

            return logTable.InsertOneAsync(document);
        }
    }
}
