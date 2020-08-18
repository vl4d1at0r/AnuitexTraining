using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace AnuitexTraining.BusinessLogicLayer.Helpers
{
    public static class EmailHelper
    {
        public static MailAddress fromEmail = new MailAddress("testcsharpsmtp0@gmail.com");
        public static string confirmationUrl = "https://localhost:44334/api/users/confirmation";
        public static void SendConfirmationMessage(string code, string email)
        {
            MailAddress toEmail = new MailAddress(email);
            MailMessage message = new MailMessage(fromEmail, toEmail);
            message.Subject = "Confirmation Link";
            message.Body = $"Your confirmation link: {confirmationUrl}/{code}";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(fromEmail.Address, "P!W`k~'NHd^y{4Zu");
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
