using System.Net;
using System.Net.Mail;

public static class EmailUtils
{


  public static async Task<string> SendVerificationEmail(VerificationEmailContext context)
  {
    var path = Directory.GetCurrentDirectory() + "";
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

    var email = new EmailOptions()
    {
      Email = context.Email,
      Subject = "Xác thực tài khoản",
      Html = htmlEmail
    };

    await SendMail(email);
    return null;

  }// Email utility methods would go here


  public static async Task<string> SendMail(EmailOptions options)
  {
    try
    {
      var builder = new ConfigurationBuilder().SetBasePath(".").AddJsonFile("appsettings.json").Build();
      if (builder != null)
      {
        var emailSettings = new SmtpClient
        {
          Host = builder["EmailSettings:EMAIL_HOST"],
          Port = 587,
          EnableSsl = true,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          UseDefaultCredentials = false,
          Credentials = new NetworkCredential(builder["EmailSettings:EMAIL_USERNAME"], builder["EmailSettings:EMAIL_PASSWORD"])
        };

        var from = new MailAddress(builder["EmailSettings:EMAIL_FROM_NAME"], builder["EmailSettings:EMAIL_FROM"]);
        var to = new MailAddress(options.Email, options.Text);
        var emailMessage = new MailMessage();
        emailMessage.From = from;
        emailMessage.To.Add(to);
        emailMessage.Subject = options.Subject;
        emailMessage.Body = options.Html;
        await emailSettings.SendMailAsync(emailMessage);
        return "Email sent successfully";
      }
      return null;
    }
    catch (System.Exception ex)
    {
      return "Error" + ex.ToString();
      throw;
    }

  }

}






public class VerificationEmailContext
{
  public string Email { get; set; }
  public string Token { get; set; }

  public string Username { get; set; }
  // Other email context properties
}

public class EmailOptions
{
  public string Email { get; set; }
  public string Subject { get; set; }

  public string Html { get; set; }

  public string Text { get; set; }
}