
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public static class AuthUtils
{

    public static string GenerateToken()    
    {
        var secret = "your_secret_key"; // Replace with your actual secret key
        var expiresIn = DateTime.UtcNow.AddHours(1);
        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "user_id"),
        
        };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            EncryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256),
            Expires = expiresIn,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static string GenerateVerificationToken( string userId)
    {
        var secret  = "your_secret_key"; // Replace with your actual secret key
        // Implement token generation logic here
        var expiresIn = DateTime.UtcNow.AddHours(1);

         var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim("type", "verification")
            
        };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiresIn,
               EncryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
    public static string HashPassword(string password)
    { 

        var saltRounds = 12; // Adjust the cost factor as needed
        // Implement password hashing logic here
        return BCrypt.Net.BCrypt.HashPassword(password, saltRounds);
    }



    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Implement password verification logic here
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }


}