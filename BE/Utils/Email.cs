public static class EmailUtils
{

    public static  async Task<void> SendVerificationEmail (VerificationEmailContext context)
    {
        var verificationLink = $"https://yourdomain.com/auth/verify-email/{context.Token}";
        var displayName = context.Username ?? "Bạn";


        var htmlEmail = $@"<div style=""font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;"">
        <div style=""text-align: center; margin-bottom: 30px;"">
          <h1 style=""color: #333; font-size: 24px;"">Xác thực tài khoản</h1>
        </div>
        
        <div style=""background-color: #f9f9f9; padding: 20px; border-radius: 8px; margin-bottom: 20px;"">
          <p style=""color: #555; font-size: 16px; line-height: 1.6;"">
            Xin chào ${displayName},
          </p>
          <p style=""color: #555; font-size: 16px; line-height: 1.6;"">
            Cảm ơn bạn đã đăng ký tài khoản với YOLO LMS. Để hoàn tất quá trình đăng ký, 
            vui lòng nhấp vào nút bên dưới để xác thực địa chỉ email của bạn:
          </p>
        </div>

        <div style=""text-align: center; margin: 30px 0;"">
          <a href=""{verificationLink}
             style=""display: inline-block; padding: 15px 30px; background-color: #4CAF50; 
                    color: white; text-decoration: none; border-radius: 6px; font-weight: bold; 
                    font-size: 16px; transition: background-color 0.3s;"">
            Xác thực email
          </a>
        </div>

        <div style=""background-color: #fff3cd; border: 1px solid #ffeaa7; padding: 15px; border-radius: 6px; margin: 20px 0;"">
          <p style=""color: #856404; font-size: 14px; margin: 0;"">
            <strong>Lưu ý:</strong> Liên kết này sẽ hết hạn sau 24 giờ.
          </p>
        </div>

        <div style=""border-top: 1px solid #eee; padding-top: 20px; margin-top: 30px;"">
          <p style=""color: #888; font-size: 14px; text-align: center;"">
            Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email này.<br>
            Nếu nút không hoạt động, bạn có thể sao chép và dán liên kết sau vào trình duyệt:<br>
            <span style=""word-break: break-all;"">{verificationLink}</span>
          </p>
        </div>
      </div>";
    }// Email utility methods would go here
}

public static async Task<void> SendMail (EmailOptions options )
{

    var emailSettings = new EmailSettings
    {
        Host = "smtp.your-email-provider.com",
        Port = 587,
        Username = "",
        Password = "",
        FromEmail = "",
        FromName = "LMS Support"
    };

    var emailMessage = new MimeMessage();
    emailMessage.From.Add(new MailboxAddress(emailSettings.FromName, emailSettings.FromEmail));
    emailMessage.To.Add(MailboxAddress.Parse(options.Email));
    emailMessage.Subject = options.Subject;

    var bodyBuilder = new BodyBuilder
    {
        HtmlBody = options.Html,
        TextBody = options.Text
    };
    emailMessage.Body = bodyBuilder.ToMessageBody();

    using (var client = new SmtpClient())
    {
        await client.ConnectAsync(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(emailSettings.Username, emailSettings.Password);
        await client.SendAsync(emailMessage);
        await client.DisconnectAsync(true);
    }
  

}





class  VerificationEmailContext
{
    public string Email { get; set; }
    public string Token { get; set; }

    public string Username { get; set; }
    // Other email context properties
}

interface EmailOptions
{
    string Email { get; set; }
    string Subject { get; set; }    

    string Html { get; set; }

    string Text { get; set; }
}