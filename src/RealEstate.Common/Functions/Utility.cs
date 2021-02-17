using System;
using System.Net.Mail;
using src.RealEstate.Common.Enum;

namespace src.RealEstate.Common.Functions
{
    public static class Utility
    {
        // Kullanıcı adı ile mi e-posta ile mi giriş yapıldığını tespit eder.
        public static LoginProvider GetLoginProvider(string username)
        {
            try
            {
                var mailAddress = new MailAddress(username);
                return LoginProvider.Email;
            }
            catch (Exception)
            {
                return LoginProvider.Username;
            }
        }
    }
}