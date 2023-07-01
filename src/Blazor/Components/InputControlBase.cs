using Microsoft.AspNetCore.Components.Rendering;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public abstract class InputControlBase<T> : InputBase<T>
    {
        
        protected override void BuildInputClass(List<string> classList)
        {
            classList.Add("textbox");
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");

            builder.AddAttribute(1, "class", GetClass());



            //Input itself
            BuildInput(builder);

            //Floating label
            if (Header != null)
            {
                builder.OpenElement(50, "span");
                builder.AddAttribute(51, "class", "floating-label");
                builder.AddContent(52, Header);
                builder.CloseElement();
            }

            //Validation message
            if (!string.IsNullOrEmpty(ValidationResult.Message))
            {
                builder.OpenElement(53, "span");
                builder.AddAttribute(54, "class", ValidationResult.Success ? "success-label" : "error-label");
                builder.AddContent(55, ValidationResult.Message);
                builder.CloseElement();
            }

            builder.CloseElement();
        }

        protected virtual void BuildInput(RenderTreeBuilder builder)
        {
            builder.OpenElement(10, "input");
            builder.AddAttribute(13, "placeholder", Placeholder ?? " ");
            builder.AddAttribute(14, "type", GetInputType());
            builder.AddAttribute(15, "onchange", OnChange);
            builder.AddAttribute(16, "value", ParseInputDisplayValue(Value));
            builder.CloseElement();
        }

        protected virtual string GetInputType()
        {
            return "text";
        }

        protected virtual object? ParseInputDisplayValue(T? value)
        {
            return value;
        }
    }
}
