using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class DBconnectionService

{
    public static IMongoClient _mongoClient;
    public static IMongoDatabase _database;
    private readonly string _connectionString;
    private readonly string _databaseName;

    public DBconnectionService(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        _databaseName = configuration.GetValue<string>("ConnectionStrings:DataBaseName");

    }
    private static readonly object lockObj = new object();
    public IMongoDatabase Database
    {

        get
        {
            if (_database == null)
            {
                lock (lockObj)
                {

                    try
                    {
                    _mongoClient = new MongoClient(_connectionString);  // MongoDB Client connection
                    _database = _mongoClient.GetDatabase(_databaseName); // Access the specified database
                    }
                    catch (System.Exception)
                    {
                        
                        throw;
                    }
                   

                }
            }
            return _database;
        }
    }
}