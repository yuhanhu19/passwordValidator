using System;
using System.Xml.Schema;

namespace passwordValidator
{
    public class PasswordValidator
    {
        public ValidationResult Validate(string password)
        {
            if (password.Length < 8)
            {
                return new ValidationResult(false, "Password must be at least 8 characters");
            }

            return new ValidationResult(true, "none");
        }
    }
}