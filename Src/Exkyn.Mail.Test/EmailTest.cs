using Exkyn.Mail.Configurations;

namespace Exkyn.Mail.Test
{
    [TestClass]
    public class EmailTest
    {
        private readonly SendingEmailConfiguration _config;
        private const string _subject = "Mensagem de Teste";
        private const string _message = "Mensagem de teste, disparado pelo sistema de teste.";

        public EmailTest() => _config = new SendingEmailConfiguration("seu_email@email.com.br", "senha_do_email");

        [TestMethod]
        public void EnviaParaUmEmail()
        {
            var sendEmail = new Email(_config);
            sendEmail.Send("email@email.com.br", _subject, _message);
        }

        [TestMethod]
        public void EnviaParaUmaListaDeEmail()
        {
            var sendEmail = new Email(_config);

            sendEmail.Send(new List<string>
            {
                "email1@email.com.br",
                "email2@email.com.br"
            }, _subject, _message);
        }
    }
}