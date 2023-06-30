using Microsoft.AspNetCore.Components;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public abstract class InputBase<TValue> : ControlBase, IValidatable
    {

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public EventCallback<TValue?> ValueChanged { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public string? Header { get; set; }

        [Parameter]
        public ValidationResult ValidationResult { get; set; } = ValidationResult.Succeeded();

        [Parameter]
        public EventCallback<ValidationResult> ErrorStateChanged { get; set; }

        [Parameter]
        public Func<TValue?, Task<ValidationResult>>? Validate { get; set; }

        protected async Task OnChange(ChangeEventArgs e)
        {
            Value = GetValue(e.Value);

            await ValueChanged.InvokeAsync(Value);

            await InvokeValidate();
        }

        protected abstract TValue? GetValue(object? value);

        public virtual async Task<bool> InvokeValidate()
        {
            if (Validate != null)
            {
                var validationResult = await Validate.Invoke(Value);
                ValidationResult = validationResult;
                await ErrorStateChanged.InvokeAsync(validationResult);
                return ValidationResult.Success;
            }
            else
            {
                return true;
            }
        }

        protected override sealed void BuildClass(List<string> classList)
        {
            base.BuildClass(classList);
            
            BuildInputClass(classList);

            if (!ValidationResult.Success)
            {
                classList.Add("error");
            }
        }

        protected virtual void BuildInputClass(List<string> classList)
        {

        }
    }
}
