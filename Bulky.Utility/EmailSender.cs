using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;


namespace Bulky.Utility
{
    public class EmailSender : IEmailSender
    {
        private Email _email;
        private readonly SecretArea _config;

        public EmailSender(IOptions<SecretArea> config)
        {
            _config = config.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var _email = new Email(new EmailParams
            {
                HostSmtp = _config.HostSmtp,
                Port = 587,
                EnableSsl = true,
                SenderName = subject,
                SenderEmail = _config.Email,
                SenderEmailPassword = _config.KeyForAdm,
            });

            await _email.Send(subject, htmlMessage , email);

        }
    }
}
