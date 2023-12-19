namespace Exkyn.Mail.Validations
{
    internal class StringValidation
    {
        public static void String(string value) => ArgumentException.ThrowIfNullOrEmpty(value);
    }
}
