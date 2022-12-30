using System;
using Xunit;

namespace passwordValidator
{
    public class Tests
    {
        [Fact]
        public void ShouldReturnErrorWhenPasswordFewerThan8Chars()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("11234A%");
            Assert.False(validationResult.Passed);
            Assert.Equal("Password must be at least 8 characters", validationResult.Message);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordContainsFewerThan2Numbers()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("Abcdefgh1%");
            Assert.False(validationResult.Passed);
            Assert.Equal("The password must contain at least 2 numbers", validationResult.Message);
        }

        [Fact]
        public void ShouldReturnErrorsGivenEmptyPassword()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("");
            Assert.False(validationResult.Passed);
            Assert.Equal("Password cannot be empty\nPassword must be at least 8 characters\nThe password must " +
                         "contain at least 2 numbers\npassword must contain at least one capital letter\npassword must " +
                         "contain at least one special character",
                validationResult.Message);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordContainsNoCapitalLetter()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("123abcde%");
            Assert.False(validationResult.Passed);
            Assert.Equal("password must contain at least one capital letter", validationResult.Message);
        }

        [Fact]
        public void ShouldReturnErrorWhenPasswordContainsNoSpecialCharacter()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("123Abcde");
            Assert.False(validationResult.Passed);
            Assert.Equal("password must contain at least one special character", validationResult.Message);
        }

        [Fact]
        public void ShouldReturnTrueGivenValidPassword()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("123Abcde$");
            Assert.True(validationResult.Passed);
            Assert.Equal("", validationResult.Message);
        }
    }
}