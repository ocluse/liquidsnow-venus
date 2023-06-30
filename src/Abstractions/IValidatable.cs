namespace Ocluse.LiquidSnow.Venus
{
    public interface IValidatable
    {
        Task<bool> InvokeValidate();

        ValidationResult ValidationResult { get; set; }
    }
}
