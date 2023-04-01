namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public interface IValidatable
    {
        Task<bool> InvokeValidate();

        ValidationResult ValidationResult { get; set; }
    }

    public interface IDropdownLayout
    {
        event Action<IDropdown>? DropdownClicked;
        event Action Clicked;
        void OnDropdownClicked(IDropdown dropdown);
    }

    public interface IDropdown
    {

    }
}
