using Exkyn.Mail.Validations;
using System.Diagnostics.CodeAnalysis;

namespace Exkyn.Mail.Configurations
{
    public class SendingEmailConfiguration
    {
        private string GetSmtpHost(string email) => "mail." + email.Split('@')[1].Trim();

        [MemberNotNull(nameof(Email), nameof(Password), nameof(Host))]
        private void EnterEmailAndPassword(string email, string password)
        {
            EmailValidation.Email(email);
            StringValidation.String(password);

            Email = email;
            Password = password;
            Host = GetSmtpHost(email);
        }

        public SendingEmailConfiguration(string email, string password) => EnterEmailAndPassword(email, password);

        public SendingEmailConfiguration(string displayName, string email, string password)
        {
            EnterEmailAndPassword(email, password);

            StringValidation.String(displayName);

            DisplayName = displayName;
        }

        /// <summary>
        /// Nome do e-mail do remetente
        /// </summary>
        public string? DisplayName { get; private set; }

        /// <summary>
        /// E-mail do remetente
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Senha do e-mail do remetente
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Host do e-mail do remetente
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Porta a ser usada para envio do e-mail, caso não seja informada será usada a porta padrão 587
        /// </summary>
        public ushort Port { get; set; } = 587;

        /// <summary>
        /// Habilita ou desabilita o envio do e-mail por uma conexão SSL. Padrão é falso, só deve ser habilitada se o host do servidor possuir SSL para envio de e-mail
        /// </summary>
        public bool UseSsl { get; set; }
    }
}
