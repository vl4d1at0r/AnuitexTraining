namespace AnuitexTraining.Shared.Constants
{
    public partial class Constants
    {
        public class EmailProviderOptions
        {
            public const string EmailConfirmationUrl = "https://localhost:5001/account/confirmEmail";
            public const string PasswordResetUrl = "https://localhost:5001/account/resetPassword";
            public const string Email = "testcsharpsmtp0@gmail.com";
            public const string Password = "P!W`k~'NHd^y{4Zu";
            public const string SmtpUrl = "smtp.gmail.com";
            public const string EmailConfirmationSubject = "Email Confirmation Link";
            public const string EmailConfirmationMessage = "Your email confirmation link: {0}?id={1}&code={2}";
            public const string PasswordResetSubject = "Pasword Reset Link";
            public const string PasswordResetMessage = "Your new password is: {0}";
        }
    }
}