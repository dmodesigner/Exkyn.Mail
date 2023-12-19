using Exkyn.Mail.Configurations;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using Exkyn.Mail.Validations;

namespace Exkyn.Mail
{
    public class Email
    {
        private MailMessage _mailMessage;
        private SmtpClient _smtpClient;

        private void AddEmail(string email)
        {
            EmailValidation.Email(email);
            _mailMessage.To.Add(email);
        }

        private void AddSubject(string subject)
        {
            StringValidation.String(subject);
            _mailMessage.Subject = subject;
        }

        private void AddMessage(string message)
        {
            StringValidation.String(message);

            _mailMessage.Body = message;
        }

        private void SendEmail()
        {
            try
            {
                _smtpClient.Send(_mailMessage);
            }
            catch (Exception e)
            {
                var msgErro = e.Message;

                if (e.InnerException != null && !string.IsNullOrEmpty(e.InnerException.Message))
                    msgErro = e.InnerException.Message;

                throw new Exception(msgErro);
            }
        }

        public Email(SendingEmailConfiguration sendingEmailConfiguration)
        {
            if (sendingEmailConfiguration is null)
                throw new ArgumentNullException("Informe um objeto de configuração para o envio do e-mail.");

            StringValidation.String(sendingEmailConfiguration.Host);

            _smtpClient = new SmtpClient(sendingEmailConfiguration.Host);

            _smtpClient.Port = sendingEmailConfiguration.Port;
            _smtpClient.EnableSsl = sendingEmailConfiguration.UseSsl;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential(sendingEmailConfiguration.Email, sendingEmailConfiguration.Password);

            _mailMessage = new MailMessage();

            _mailMessage.From = new MailAddress(sendingEmailConfiguration.Email, sendingEmailConfiguration.DisplayName);
            _mailMessage.IsBodyHtml = true;
        }

        /// <summary>
        /// Faz o envio do e-mail para um destinatalio
        /// </summary>
        /// <param name="email">E-mail do destinatário</param>
        /// <param name="subject">Assunto do e-mail para o destinatário</param>
        /// <param name="message">Mensagem para o destinatário. Pode ser com <html> ou apenas texto.</param>
        /// <returns></returns>
        public bool Send(string email, string subject, string message)
        {
            AddEmail(email);

            AddSubject(subject);

            AddMessage(message);

            SendEmail();

            return true;
        }

        /// <summary>
        /// Envia e-mails para múltiplos e-mails
        /// </summary>
        /// <param name="emails">Lista de e-mail de destinatários</param>
        /// <param name="subject">Assunto do e-mail para o destinatário</param>
        /// <param name="message">Mensagem para o destinatário. Pode ser com <html> ou apenas texto.</param>
        /// <returns></returns>
        public bool Send(List<string> emails, string subject, string message)
        {
            foreach (var email in emails)
            {
                AddEmail(email);
            }

            AddSubject(subject);

            AddMessage(message);

            SendEmail();

            return true;
        }
    }
}
