namespace passwordValidator
{
    public class ValidationResult
    {
        public ValidationResult(bool passed, string message)
        {
            this.Passed = passed;
            this.Message = message;
        }

        public bool Passed { get; set; }

        public string Message { get; set; }
    }
}