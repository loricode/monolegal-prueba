using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PersistenceMonolegal.Conexion
{
    public class FactoryConnection : IFactoryConnection
    {
        private IMongoDatabase _database = null!;

        private readonly IOptions<ConnectionConfiguration> _configs;
        public FactoryConnection(IOptions<ConnectionConfiguration> configs) {
            _configs = configs;
        }

        public IMongoDatabase Connect()
        {

            if (_database == null)

            {
                var mongoClient = new MongoClient(_configs.Value.ConnectionString);
            
                _database = mongoClient.GetDatabase(_configs.Value.DatabaseName);
            }

            return _database;
        }

    }
}
