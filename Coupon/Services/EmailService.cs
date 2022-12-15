using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon.Services
{
    public class EmailService
    {

        public async void SendEmail()
        {
            var client = new SendGridClient("");
            var from = new EmailAddress("", "");
            var _to = new EmailAddress("");

            var msg = MailHelper.CreateSingleEmail(from, _to, "Email", "Text", "");
            var response = await client.SendEmailAsync(msg);
        }
    }
}
