using MongoDB.Bson;
using MongoDB.Driver;

public class DefaultService
{
    public DBconnectionService _DatabaseService { get; set; }

    public DefaultService(DBconnectionService dbConnectionService)
    {
        _DatabaseService = dbConnectionService;

    }

    /// <summary>
    /// Retrieves a student from the database.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the student if found, otherwise null.
    /// </returns>
    public async Task<Object> GetStudent()
    {
        var studentCollection = _DatabaseService.Database.GetCollection<Object>("neighborhoods");
        var student = studentCollection.Find(new BsonDocument()).FirstOrDefault();
        return student;
    }
}