using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Service
{
    public class MailService
    {
        public string receiver_Email { get; set; }
        public string receiver_FullName { get; set; }
        public string Mail_Subject { get; set; }
        public string Mail_Body { get; set; }


        public void SendEmail()
        {

            var senderEmail = new MailAddress("mohamedamine.elhaddad@esprit.tn", "amine");
            var receiverEmail = new MailAddress(this.receiver_Email, this.receiver_FullName);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, "PChpw2228h")
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = this.Mail_Subject,
                Body = this.Mail_Body
            })
            {
                smtp.Send(mess);
            }
        }
    }
}
