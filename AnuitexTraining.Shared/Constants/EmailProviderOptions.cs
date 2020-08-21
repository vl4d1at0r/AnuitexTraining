using System;
using System.Collections.Generic;
using System.Text;

namespace AnuitexTraining.Shared.Constants
{
    public partial class Constants
    {
        public partial class EmailProviderOptions
        {
            public const string EmailConfirmationUrl = "https://localhost:44334/api/accounts/confirmEmail";
            public const string PasswordResetUrl = "https://localhost:44334/account/resetPassword";
            public const string Email = "testcsharpsmtp0@gmail.com";
            public const string Password = "P!W`k~'NHd^y{4Zu";
            public const string SmtpUrl = "smtp.gmail.com";
        }
    }
}
