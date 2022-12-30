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
            if (password.Length < 8)
            {
                return new ValidationResult(false, "Password must be at least 8 characters");
            }

            if (CountNumbersInPassword(password) < 2)
            {
                return new ValidationResult(false, "The password must contain at least 2 numbers");

            }

            return new ValidationResult(true, "none");
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