public interface RegisterData
{
    string Username { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    UserType? UserType{ get; set; }
}