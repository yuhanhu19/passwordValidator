using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace passwordValidator
{
    public class PasswordValidator
    {
        public ValidationResult Validate(string password)
        {
            IList<string> errors = new List<string>();

            if (password.Length < 8)
            {
                errors.Add("Password must be at least 8 characters");
            }

            if (CountNumbersInPassword(password) < 2)
            {
                errors.Add("The password must contain at least 2 numbers");
            }

            if (!password.Any(char.IsUpper))
            {
                errors.Add("password must contain at least one capital letter");
            }

            if (password.All(char.IsLetterOrDigit))
            {
                errors.Add("password must contain at least one capital letter");
            }

            if (!errors.Any())
            {
                return new ValidationResult(true, "none");
            }

            return new ValidationResult(false, string.Join("\n", errors));
        }
        
        private int CountNumbersInPassword(string password)
        {
            return password.Where(IsNumber).ToList().Count;
        }

        private bool IsNumber(char c)
        {
            return int.TryParse(c.ToString(), out _);
        }
    }
}