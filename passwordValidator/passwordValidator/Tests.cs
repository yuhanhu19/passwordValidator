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
            var validationResult = passwordValidator.Validate("11234A");
            Assert.False(validationResult.Passed);
            Assert.Equal("Password must be at least 8 characters", validationResult.Message);

        }
        
        [Fact]
        public void ShouldReturnErrorWhenPasswordContainsFewerThan2Numbers()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("Abcdefgh1");
            Assert.False(validationResult.Passed);
            Assert.Equal("The password must contain at least 2 numbers", validationResult.Message);

        }
        
        [Fact]
        public void ShouldReturnMultipleErrorsWhenHappen()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("Abc1");
            Assert.False(validationResult.Passed);
            Assert.Equal("Password must be at least 8 characters\nThe password must contain at least 2 numbers", validationResult.Message);

        }
        
        [Fact]
        public void ShouldReturnErrorWhenPasswordContainsNoCapitalLetter()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("123abcde");
            Assert.False(validationResult.Passed);
            Assert.Equal("password must contain at least one capital letter", validationResult.Message);

        }
    }
}