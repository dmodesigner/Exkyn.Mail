# Exkyn Mail

Esse projeto possibilita enviar e-mail seguindo boas práticas da plataforma .NET. Tendo recursos como validações para minimizar os erros e com uma pequena configuração (demostrada mais abaixo) poder enviar e-mails.


## Instalação

Você pode instalar esse projeto pelo Nuget

```bash
  dotnet add package Exkyn.Mail --version 8.0.0
```
    
## Exemplo de Uso

```c#
using Exkyn.Mail;
using Exkyn.Mail.Configurations;

//Cria a configuração do e-mail que enviara as mensagens
var configuration = new SendingEmailConfiguration("remetente@email.com.br", "senha_email_remetente");

//Instancia a classe com a configuração para envio do e-mail
var sendEmail = new Email(_config);

//Envia o e-mail
sendEmail.Send("destinatario@email.com.br", "Assunto da mensagem", "Mensagem que deseja enviar.");
```


## Autores

- [@Daniel Moura](https://github.com/dmodesigner)


## Licença

Esse projeto pode ser usado de forma livre. É oferecido sobre a Licença [MIT](https://github.com/dmodesigner/Exkyn.Mail/blob/main/LICENSE.txt)