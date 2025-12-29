using MongoDB.Driver;

public class DefaultService
{
    public DBconnectionService _DatabaseService { get; set; }

    public DefaultService(DBconnectionService dbConnectionService)
    {
        _DatabaseService = dbConnectionService;

    }

    public async Task<Student> GetStudent()
    {
        var studentCollection = _DatabaseService.Database.GetCollection<Student>("restaurant");
        var student = await studentCollection.Find(_ => true).FirstOrDefaultAsync();
        return student;
    }
}