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
            var client = new SendGridClient("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");
            var from = new EmailAddress("no-reply@kafahh.com", "منصة كفاءة");
            var _to = new EmailAddress("mo7ammedbinabdul@gmail.com");

            var msg = MailHelper.CreateSingleEmail(from, _to, "Email", "Text", "");
            var response = await client.SendEmailAsync(msg);
        }
    }
}
