using System;
using System.Net;
using System.Net.Mail;
using Myntra_App.ExceptionHandling;
using System.Configuration;

namespace Myntra_App.MailReport
{
    public class SendMail
    {
        public static void SendEmailMethod()
        {
            try
            {
                MailMessage mail = new MailMessage();
                string fromEmail = ConfigurationManager.AppSettings["Email"];
                string password = ConfigurationManager.AppSettings["emailPassword"];
                string ToEmail = ConfigurationManager.AppSettings["toReportEmail"];
                mail.From = new MailAddress(fromEmail);
                mail.Subject = "Myntra App Test Report";
                mail.To.Add(ToEmail);
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(@"C:\Users\Nitikesh\source\repos\Myntra_App\Myntra_App\ExtentReports\index.html"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                throw new CustomException("Error while sending mail", CustomException.ExceptionType.COULD_NOT_SEND_EMAIL);
            }
        }
    }
}
