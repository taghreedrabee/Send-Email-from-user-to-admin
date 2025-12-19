using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using palmHillsapp.Interfaces;
using palmHillsapp.Classes; 


namespace palmHillsapp.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> settings,
                            ILogger<EmailService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task SendBookCallEmailAsync(EmailSender model)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(model.FullName, _settings.Email));

            email.To.Add(MailboxAddress.Parse("name@example.com"));


            email.ReplyTo.Add(new MailboxAddress(model.FullName, model.EmailAddress));

            email.Subject = $"New Book a Call Request from {model.FullName}";

            email.Body = new TextPart("html")
            {
                Text = $"""
        <div style="font-family: Arial, sans-serif; padding: 20px; background-color: #f5f5f5;">
            <div style="background-color: white; padding: 30px; border-radius: 10px; max-width: 600px; margin: 0 auto;">
                <h2 style="color: #2c3e50; border-bottom: 3px solid #3498db; padding-bottom: 10px;">
                    📞 New Call Request
                </h2>
                
                <div style="margin: 20px 0; padding: 15px; background-color: #ecf0f1; border-radius: 5px;">
                    <p style="margin: 10px 0;"><strong>👤 Name:</strong> {model.FullName}</p>
                    <p style="margin: 10px 0;"><strong>📧 Email:</strong> 
                        <a href="mailto:{model.EmailAddress}" style="color: #3498db; text-decoration: none;">
                            {model.EmailAddress}
                        </a>
                    </p>
                    <p style="margin: 10px 0;"><strong>📱 Phone:</strong> {model.phoneNumber}</p>
                    <p style="margin: 10px 0;"><strong>🏢 Interested In:</strong> 
                        <span style="background-color: #3498db; color: white; padding: 3px 10px; border-radius: 3px;">
                            {model.InterestedIn}
                        </span>
                    </p>
                </div>
                
                <div style="margin: 20px 0; padding: 15px; background-color: #fff3cd; border-left: 4px solid #ffc107; border-radius: 5px;">
                    <p style="margin: 0;"><strong>💬 Message:</strong></p>
                    <p style="margin: 10px 0; color: #555;">{model.Message}</p>
                </div>
                
                <hr style="border: none; border-top: 1px solid #ddd; margin: 20px 0;">
                
                <p style="color: #7f8c8d; font-size: 12px; text-align: center;">
                    ⚡ This email was sent from Palm Hills Contact Form<br>
                    Click "Reply" to respond directly to {model.FullName}
                </p>
            </div>
        </div>
        """
            };

            try
            {
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_settings.server, _settings.port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_settings.Email, _settings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                _logger.LogInformation("Email sent to admin from user {UserEmail}", model.EmailAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Email sending failed");
                throw;
            }
        }
    }
}