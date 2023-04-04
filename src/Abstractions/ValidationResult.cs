namespace Ocluse.LiquidSnow.Venus
{
    public struct ValidationResult
    {
        public string? Message { get; set; }
        public bool Success { get; set; }

        public static ValidationResult Succeeded()
        {
            return new() { Success = true, Message = null };
        }

        public static ValidationResult Failed(string message)
        {
            return new() { Message = message, Success = false };
        }
    }
}
