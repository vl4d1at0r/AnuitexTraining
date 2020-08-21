using System.Net.Mail;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.BusinessLogicLayer.Providers
{
    public class EmailProvider
    {
        private MailAddress _mailAddress;
        private SmtpClient _smtpClient;

        public EmailProvider()
        {
            _mailAddress = new MailAddress(EmailProviderOptions.Email);
            _smtpClient = new SmtpClient(EmailProviderOptions.SmtpUrl)
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(EmailProviderOptions.Email, EmailProviderOptions.Password),
                EnableSsl = true
            };
        }

        public async Task SendEmailConfirmationMessageAsync(long id, string code, string email)
        {
            MailMessage message = new MailMessage(_mailAddress, new MailAddress(email));
            message.Subject = "Email Confirmation Link";
            message.Body = $"Your email confirmation link: {EmailProviderOptions.EmailConfirmationUrl}?id={id}&code={HttpUtility.UrlEncode(code)}";
            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendPasswordResetMessageAsync(long id, string code, string email)
        {
            MailMessage message = new MailMessage(_mailAddress, new MailAddress(email));
            message.Subject = "Pasword Reset Link";
            message.Body = $"Your password reset link: {EmailProviderOptions.PasswordResetUrl}?id={id}&code={HttpUtility.UrlEncode(code)}";
            await _smtpClient.SendMailAsync(message);
        }
    }
}
