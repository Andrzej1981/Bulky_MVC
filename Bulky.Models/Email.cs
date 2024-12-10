using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class Email
    {
        private SmtpClient smtpClient;
        private MailMessage message;
        private string _hostSmtp;
        private bool _enableSsl;
        private MailMessage _mail;
        private int _port;
        private string _senderEmail;
        private string _senderEmailPassword;
        private string _senderName;
        
        public Email(EmailParams emailParams) 
        {
            _hostSmtp = emailParams.HostSmtp;
            _enableSsl = emailParams.EnableSsl;
            _port = emailParams.Port;  
            _senderEmail = emailParams.SenderEmail;
            _senderEmailPassword = emailParams.SenderEmailPassword; 
            _senderName = emailParams.SenderName;
            
        }

        public void Send(string subject, string body, string to)
        {
            _mail = new MailMessage();
        }
        
    }
}
