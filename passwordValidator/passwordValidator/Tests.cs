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
            var validationResult = passwordValidator.Validate("11234");
            Assert.False(validationResult.Passed);
            Assert.Equal("Password must be at least 8 characters", validationResult.Message);

        }
        
        [Fact]
        public void ShouldReturnErrorWhenPasswordContainsFewerThan2Numbers()
        {
            var passwordValidator = new PasswordValidator();
            var validationResult = passwordValidator.Validate("abcdefgh1");
            Assert.False(validationResult.Passed);
            Assert.Equal("The password must contain at least 2 numbers", validationResult.Message);

        }
    }
}