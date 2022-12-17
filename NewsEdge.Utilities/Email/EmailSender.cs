using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewsEdge.Utilities.Email.Body;

namespace NewsEdge.Utilities.Email
{
    public class EmailSender
    {
        public static async Task SendConfirmEmail(string to, string confirmLink)
        {
            await SendEmail(to, "تائید ایمیل شما", EmailBody.ConfirmEmailBody(confirmLink));
        }

        public static async Task SendForgotPasswordEmail(string to, string resetLink)
        {
            await SendEmail(to, "بازیابی رمز عبور شما", EmailBody.ForgotPasswordEmailBody(resetLink));
        }

        private static async Task SendEmail(string to, string subject, string body)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("mahdi1383harold@outlook.com");
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("mahdi1383harold@outlook.com", "m4#d1@4l1");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}
