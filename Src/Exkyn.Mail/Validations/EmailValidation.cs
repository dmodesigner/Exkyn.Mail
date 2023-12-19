using System.Text.RegularExpressions;

namespace Exkyn.Mail.Validations
{
    internal class EmailValidation
    {
        public static bool Email(string email)
        {
            StringValidation.String(email);

            var regex = new Regex("^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$");

            var match = regex.Match(email);

            return match.Success;
        }
    }
}
