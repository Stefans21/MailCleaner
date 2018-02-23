using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace MailCleaner
{
    public class SendMail
    {
        private readonly string _sender;
        private readonly string _password;
        public SendMail(string sender, string password)
        {
            _sender = sender.Trim();
            _password = password.Trim();
        }

        public void Send(string recipient, string subject, string message)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(_sender, _password);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                MailMessage mail = new MailMessage(_sender, recipient)
                {
                    Subject = subject,
                    Body = message
                };
                client.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
