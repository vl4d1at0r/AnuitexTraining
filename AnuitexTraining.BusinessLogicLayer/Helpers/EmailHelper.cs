using System.Net.Mail;
using System.Net;
using System.Web;

namespace AnuitexTraining.BusinessLogicLayer.Helpers
{
    public static class EmailHelper
    {
        private static MailAddress fromEmail = new MailAddress("testcsharpsmtp0@gmail.com");
        private static SmtpClient client = new SmtpClient("smtp.gmail.com") { UseDefaultCredentials = true, Credentials = new NetworkCredential(fromEmail.Address, "P!W`k~'NHd^y{4Zu"), EnableSsl = true };
        private static string emailConfirmationUrl = "https://localhost:44334/api/accounts/confirmEmail";
        private static string passwordResetUrl = "https://localhost:44334/api/accounts/resetPassword";
        public static void SendEmailConfirmationMessage(long id, string code, string email)
        {
            MailMessage message = new MailMessage(fromEmail, new MailAddress(email));
            message.Subject = "Email Confirmation Link";
            message.Body = $"Your email confirmation link: {emailConfirmationUrl}?id={id}&code={HttpUtility.UrlEncode(code)}";
            client.Send(message);
        }

        public static void SendPasswordResetMessage(long id, string code, string email)
        {
            MailMessage message = new MailMessage(fromEmail, new MailAddress(email));
            message.Subject = "Pasword Reset Link";
            message.Body = $"Your password reset link: {passwordResetUrl}?id={id}&code={HttpUtility.UrlEncode(code)}";
            client.Send(message);
        }
    }
}
