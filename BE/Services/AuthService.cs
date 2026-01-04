using MongoDB.Driver;

class AuthService : IAuthService
{
    private readonly IMongoCollection<User> _usersCollection;

    private readonly DBconnectionService _dbConnectionService;


    public AuthService( DBconnectionService dbConnectionService)
    {
        _dbConnectionService = dbConnectionService;
        _usersCollection = _dbConnectionService.Database.GetCollection<User>("users");
    }
    public Task<string> Resgister(RegisterData data)
    {
        var existingUser = _usersCollection.Find(user => user.Email == data.Email).FirstOrDefault();
        if (existingUser != null)
        {
            return Task.FromResult("User with this email already exists.");
        }

        var password  = AuthUtils.HashPassword(data.Password);
        var newUser = new User
        {
         
            Username = data.Username,
            Email = data.Email,
            Password = password,
            Status = "Active",
            UserType = data.UserType.ToString(),
            Avatar = "",
            RoleName = ""
        };
        _usersCollection.InsertOne(newUser);



        //send emailverification

        var verificationToken = AuthUtils.GenerateVerificationToken(newUser._Id.ToString());
        return Task.FromResult("User registered successfully.");
    } 
}