using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace AdminPanelAPI.Service.Implementation
{
    public class EmailService
    {
        public bool SendEmail(string toemail, string body, string subject)
        {
            try
            {
                string password = ConfigurationManager.AppSettings["Password"];
                string fromemail = ConfigurationManager.AppSettings["FromEmail"];
                string client = ConfigurationManager.AppSettings["SMTP"];
                int port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                string username= ConfigurationManager.AppSettings["Username"]; 
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(client);

                mail.From = new MailAddress(fromemail);
                mail.To.Add(toemail);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(fromemail, password);
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}